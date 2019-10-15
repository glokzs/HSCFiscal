using System;
using System.Linq;
using System.Threading.Tasks;
using HSCFiscalRegistrar.DTO.Fiscalization.KKM;
using HSCFiscalRegistrar.DTO.Fiscalization.KKMResponce;
using HSCFiscalRegistrar.DTO.Fiscalization.OFD;
using HSCFiscalRegistrar.DTO.Fiscalization.OFDResponse;
using HSCFiscalRegistrar.Enums;
using HSCFiscalRegistrar.Helpers;
using HSCFiscalRegistrar.Models;
using HSCFiscalRegistrar.Models.APKInfo;
using HSCFiscalRegistrar.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using ILoggerFactory = Microsoft.Extensions.Logging.ILoggerFactory;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    public class CheckController : Controller
    {
        private readonly ApplicationContext _applicationContext;
        private readonly UserManager<User> _userManager;
        private readonly ILoggerFactory _loggerFactory;
        private readonly GenerateErrorHelper _errorHelper;
        private readonly TokenValidationHelper _helper;

        public CheckController(ApplicationContext applicationContext, UserManager<User> userManager,
            ILoggerFactory loggerFactory, TokenValidationHelper helper, GenerateErrorHelper errorHelper)
        {
            _applicationContext = applicationContext;
            _userManager = userManager;
            _loggerFactory = loggerFactory;
            _helper = helper;
            _errorHelper = errorHelper;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CheckOperationRequest checkOperationRequest)
        {
            var _logger = _loggerFactory.CreateLogger("Check|Post");

            try
            {
                _logger.LogInformation($"Информация по чеку: {checkOperationRequest.Token}");

                var error = _helper.TokenValidator(_applicationContext, checkOperationRequest.Token);
                return await Response(checkOperationRequest, _logger);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return Json(e.Message);
            }
        }

        private async Task<IActionResult> Response(CheckOperationRequest checkOperationRequest, ILogger _logger)
        {
            var user = _userManager.FindByIdAsync(_helper.ParseId(checkOperationRequest.Token));
            var oper = _applicationContext.Operators.FirstOrDefault(op => op.UserId == user.Result.Id);
            if (oper == null) return NotFound("Operator not found");
            var shift = await GetShift(oper);
            var kkm = oper.Kkm;
            try
            {
                var sum = checkOperationRequest.Payments.Sum(paymentsType => paymentsType.Sum);
                var checkNumber = GeneratorFiscalSign.GenerateFiscalSign();
                var date = DateTime.Now;
                var qr = GetUrl(kkm, checkNumber.ToString(), sum, date);
                var operation = GetOperation(shift, checkOperationRequest, date, qr, oper);
                var kkmResponse = new KkmResponse(operation, shift);
                var response = await OfdFiscalResponse(checkOperationRequest, operation);
                operation.FiscalNumber = response.Ticket.TicketNumber;
                operation.QR = response.Ticket.QrCode;
                kkm.OfdToken = response.Token;
                await UpdateDatabaseFields(kkm, operation);
                return Ok(JsonConvert.SerializeObject(kkmResponse));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                _logger.LogError($"Ошибка авторизации пользователя: {checkOperationRequest.Token}");
                return Ok(_errorHelper.GetErrorRequest((int) ErrorEnums.UNKNOWN_ERROR));
            }
        }

        private static async Task<OfdFiscalResponse> OfdFiscalResponse(CheckOperationRequest checkOperationRequest, Operation operation)
        {
            var fiscalOfdRequest = new FiscalOfdRequest(operation, checkOperationRequest);
            var x = await HttpService.Post(fiscalOfdRequest);
            string json = JsonConvert.SerializeObject(x);
            var response = JsonConvert.DeserializeObject<OfdFiscalResponse>(json);
            return response;
        }

        private async Task<Shift> GetShift(Operator oper)
        {
            Shift shift;
            if (!_applicationContext.Shifts.Any())
            {
                shift = new Shift
                {
                    OpenDate = DateTime.Now,
                    KkmId = oper.KkmId,
                    Number = 1,
                    OperatorId = oper.Id,
                };
                await _applicationContext.Shifts.AddAsync(shift);
                await _applicationContext.SaveChangesAsync();
            }
            else if (_applicationContext.Shifts.Last().CloseDate != DateTime.MinValue)
            {
                shift = new Shift
                {
                    OpenDate = DateTime.Now,
                    KkmId = oper.KkmId,
                    Number = _applicationContext.Shifts.Last().Number + 1,
                    OperatorId = oper.Id,
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
            CheckOperationRequest checkOperationRequest, DateTime date, string qr, Operator oper)
        {
            var total = checkOperationRequest.Payments.Sum(p => p.Sum);
            var operation = new Operation
            {
                Amount = total,
                Type = checkOperationRequest.OperationType,
                CardAmount = checkOperationRequest.Payments
                    .Where(p => p.PaymentType == PaymentTypeEnum.PAYMENT_CARD)
                    .Sum(p => p.Sum),
                CashAmount = checkOperationRequest.Payments
                    .Where(p => p.PaymentType == PaymentTypeEnum.PAYMENT_CASH)
                    .Sum(p => p.Sum),
                ChangeAmount = checkOperationRequest.Change,
                CheckNumber = _applicationContext.Operations.Count(s => s.ShiftId == shift.Id) + 1,
                CreationDate = date,
                IsOffline = true,
                QR = qr,
                ShiftId = shift.Id,
                OperatorId = oper.Id,
                OperationState = OperationStateEnum.New,
                KkmId = oper.KkmId,
                Operator = oper,
                Kkm = oper.Kkm
            };
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