using System;
using System.Linq;
using System.Threading.Tasks;
using HSCFiscalRegistrar.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Models;
using Models.DTO.Fiscalization.KKM;
using Models.DTO.Fiscalization.KKMResponce;
using Models.DTO.Fiscalization.OFD;
using Models.DTO.Fiscalization.OFDResponse;
using Models.DTO.RequestOperatorOfd;
using Models.Enums;
using Models.Services;
using Serilog;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    public class CheckController : Controller
    {
        private readonly ApplicationContext _applicationContext;
        private readonly UserManager<User> _userManager;
        private readonly GenerateErrorHelper _errorHelper;
        private readonly TokenValidationHelper _helper;

        public CheckController(ApplicationContext applicationContext, UserManager<User> userManager, TokenValidationHelper helper, GenerateErrorHelper errorHelper)
        {
            _applicationContext = applicationContext;
            _userManager = userManager;
            _helper = helper;
            _errorHelper = errorHelper;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CheckOperationRequest checkOperationRequest)
        {
            
            try
            {
                Log.Information("Check|Post");
                Log.Information($"Получение списка касс пользователя: {_userManager}");
                
                Log.Information($"Информация по чеку: {checkOperationRequest.Token}");
                _helper.TokenValidator(_userManager, checkOperationRequest.Token);
                return await Response(checkOperationRequest);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return Json(e.Message);
            }
        }

        private async Task<IActionResult> Response(CheckOperationRequest checkOperationRequest)
        {
            var user = _userManager.FindByIdAsync(_helper.ParseId(checkOperationRequest.Token));
            var kkm = _applicationContext.Kkms.FirstOrDefault(k => k.SerialNumber == checkOperationRequest.CashboxUniqueNumber);
            if (user == null) return NotFound("Operator not found");
            var shift = await GetShift(user.Result, kkm);
            var merchant = _userManager.Users.FirstOrDefault(u => u.Id == kkm.UserId);
            if (merchant == null) return Ok(JsonConvert.SerializeObject(_errorHelper.GetErrorRequest(3)));
            var org = new Org
            {
                Inn = merchant.Inn,
                Okved = "o",
                TaxationType = merchant.TaxationType,
                Title = merchant.Title
            };
            try
            {
                var sum = checkOperationRequest.Payments.Sum(paymentsType => paymentsType.Sum);
                var checkNumber = GeneratorFiscalSign.GenerateFiscalSign();
                var date = DateTime.Now;
                var qr = GetUrl(kkm, checkNumber.ToString(), sum, date);
                var operation = GetOperation(shift, checkOperationRequest, date, qr, user.Result, kkm);
                var kkmResponse = new KkmResponse(operation, shift);
                var response = await OfdFiscalResponse(checkOperationRequest, operation, kkm, org);
                operation.FiscalNumber = response.Ticket.TicketNumber;
                operation.QR = response.Ticket.QrCode;
                if (kkm == null) return Ok(JsonConvert.SerializeObject(_errorHelper.GetErrorRequest(6)));
                kkm.OfdToken = response.Token;
                await UpdateDatabaseFields(kkm, operation);

                return Ok(JsonConvert.SerializeObject(kkmResponse));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                Log.Error($"Ошибка авторизации пользователя: {checkOperationRequest.Token}");
                return Ok(_errorHelper.GetErrorRequest((int) ErrorEnums.UNKNOWN_ERROR));
            }
        }

        private static async Task<OfdFiscalResponse> OfdFiscalResponse(CheckOperationRequest checkOperationRequest,
            Operation operation, Kkm kkm, Org org)
        {
            var fiscalOfdRequest = new FiscalOfdRequest(operation, checkOperationRequest, kkm, org);
            var x = await HttpService.Post(fiscalOfdRequest);
            string json = JsonConvert.SerializeObject(x);
            var response = JsonConvert.DeserializeObject<OfdFiscalResponse>(json);
            return response;
        }
        private async Task<Shift> GetShift(User oper, Kkm kkm)
        {
            Shift shift;
            if (!_applicationContext.Shifts.Any())
            {
                shift = new Shift
                {
                    OpenDate = DateTime.Now,
                    KkmId = kkm.Id,
                    Number = 1,
                    UserId = oper.Id
                };
                await _applicationContext.Shifts.AddAsync(shift);
                await _applicationContext.SaveChangesAsync();
            }
            else if (_applicationContext.Shifts.Last().CloseDate != DateTime.MinValue)
            {
                shift = new Shift
                {
                    OpenDate = DateTime.Now,
                    KkmId = kkm.Id,
                    UserId =  oper.Id,
                    Number = _applicationContext.Shifts.Last().Number + 1,
                    BuySaldoBegin = _applicationContext.Shifts.Last().BuySaldoEnd,
                    SellSaldoBegin = _applicationContext.Shifts.Last().SellSaldoEnd,
                    RetunBuySaldoBegin = _applicationContext.Shifts.Last().RetunBuySaldoEnd,
                    RetunSellSaldoBegin = _applicationContext.Shifts.Last().RetunSellSaldoEnd,
                };
                await _applicationContext.Shifts.AddAsync(shift);
                await _applicationContext.SaveChangesAsync();
            }

            shift = _applicationContext.Shifts.Last();
            return shift;
        }

        private Operation GetOperation(Shift shift,
            CheckOperationRequest checkOperationRequest, DateTime date, string qr, User oper, Kkm kkm)
        {
            var total = checkOperationRequest.Payments.Sum(p => p.Sum);
            var cardAmount = checkOperationRequest.Payments
                .Where(p => p.PaymentType == PaymentTypeEnum.PAYMENT_CARD)
                .Sum(p => p.Sum);
            var cashAmount = checkOperationRequest.Payments
                .Where(p => p.PaymentType == PaymentTypeEnum.PAYMENT_CASH)
                .Sum(p => p.Sum);
            var checkNumber = _applicationContext.Operations.Count(s => s.ShiftId == shift.Id) + 1;
            var operation = new Operation(checkOperationRequest.OperationType, shift.Id, OperationStateEnum.New, false,
                date,
                qr, total, checkOperationRequest.Change, cashAmount, cardAmount, oper.Id, kkm.Id, oper, kkm,
                checkNumber);
            return operation;
        }

        private async Task UpdateDatabaseFields(Kkm kkm, Operation operation)
        {
            kkm.ReqNum += 1;
            _applicationContext.Update(kkm);
            _applicationContext.Operations.Add(operation);
            await _applicationContext.SaveChangesAsync();
        }

        private string GetUrl(Kkm kkm, string checkNumber, decimal sum, DateTime date)
        {
            var dateString = $"{date.Year}{date.Month}{date.Day}T{date.Hour}{date.Minute}{date.Second}";
            return $"http://consumer.test-oofd.kz?i={checkNumber}&f={kkm.FnsKkmId}&s={sum}&t={dateString}";
        }
    }
}