using System;
using System.Linq;
using System.Threading.Tasks;
using HSCFiscalRegistrar.DTO.Errors;
using HSCFiscalRegistrar.DTO.Fiscalization;
using HSCFiscalRegistrar.DTO.Fiscalization.KKM;
using HSCFiscalRegistrar.Enums;
using HSCFiscalRegistrar.Helpers;
using HSCFiscalRegistrar.Models;
using HSCFiscalRegistrar.Models.APKInfo;
using HSCFiscalRegistrar.Models.Operation;
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
        private readonly TokenValidationHelper _helper;
        public CheckController(ApplicationContext applicationContext, UserManager<User> userManager, ILoggerFactory loggerFactory, TokenValidationHelper helper)
        {
            _applicationContext = applicationContext;
            _userManager = userManager;
            _loggerFactory = loggerFactory;
            _helper = helper;
        }

        private async Task<IActionResult> Response(CheckOperationRequest checkOperationRequest, ILogger _logger)
        {
            var user = _userManager.FindByIdAsync(_helper.ParseId(checkOperationRequest.Token));
            var kkm = user.Result.Kkm;
            try
            {
                var sum = checkOperationRequest.Payments.Sum(paymentsType => paymentsType.Sum);

                int checkNumber = GetCheckNumber();
                var date = DateTime.Now;
                var QR = GetUrl(kkm, checkNumber.ToString(), sum, date);
                KkmResponse kkmResponse = new KkmResponse
                    {
                        Data = new Data
                            {
                                DateTime = date,
                                CheckNumber = checkNumber.ToString(),
                                OfflineMode = false,
                                Cashbox = new Cashbox
                                {
                                    Address = kkm.Address,
                                    IdentityNumber = kkm.DeviceId.ToString(),
                                    UniqueNumber = kkm.SerialNumber,
                                    RegistrationNumber = kkm.FnsKkmId
                                },
                                CashboxOfflineMode = false,
                                CheckOrderNumber = kkm.ReqNum,
                                ShiftNumber = 55,
                                EmployeeName = User.Identity.Name,
                                TicketUrl = QR,
                            }
                    }; 
              
                var operation = GetOperation(checkOperationRequest, checkNumber, date, QR, user.Result);
                await UpdateDatabaseFields(kkm, operation);
                return Ok(JsonConvert.SerializeObject(kkmResponse));
                
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                _logger.LogError($"Ошибка авторизации пользователя: {checkOperationRequest.Token}");
                return Ok(ErrorsAuth.LoginError());
            }
        }

        private Operation GetOperation(
            CheckOperationRequest checkOperationRequest, int checkNumber, System.DateTime date, string QR, User user)
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
                CheckNumber = _applicationContext.Operations.Count() + 1,
                CreationDate = date,
                FiscalNumber = checkNumber,
                IsOffline = false,
                QR = QR,
                OperatorId = user.Id    
            };
            return operation;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CheckOperationRequest checkOperationRequest)
        {
            var _logger = _loggerFactory.CreateLogger("Check|Post");
            _logger.LogInformation($"Информация по чеку: {checkOperationRequest.Token}");
           
            try
            {
                var error = _helper.TokenValidator(_applicationContext, checkOperationRequest.Token);
                return await (error == null ? Response(checkOperationRequest, _logger) : throw error);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return Json(e.StackTrace);
            }
        }
        
        private async Task UpdateDatabaseFields(Kkm kkm, Operation operation)
        {
            kkm.ReqNum += 1;
            _applicationContext.Update(kkm);
            await _applicationContext.SaveChangesAsync();
            _applicationContext.Operations.Add(operation);
            await _applicationContext.SaveChangesAsync();
        }

        private string GetUrl(Kkm kkm, string checkNumber, decimal sum, DateTime date)
        {
            string dateString = $"{date.Year}{date.Month}{date.Day}T{date.Hour}{date.Minute}{date.Second}";
            return $"http://consumer.test-oofd.kz?i={checkNumber}&f={kkm.FnsKkmId}&s={sum}&t={dateString}";
        }

        private int GetCheckNumber()
        {
           var random = new Random();
           return random.Next(999999999);
        }
        
    }
}