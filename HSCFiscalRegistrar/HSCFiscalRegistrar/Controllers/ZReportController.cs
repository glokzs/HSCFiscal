using System.Collections.Generic;
using System.Linq;
using Castle.Core.Logging;
using HSCFiscalRegistrar.DTO.XReport;
using HSCFiscalRegistrar.DTO.XReport.KkmResponce;
using HSCFiscalRegistrar.Enums;
using HSCFiscalRegistrar.Helpers;
using HSCFiscalRegistrar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DateTime = System.DateTime;

namespace HSCFiscalRegistrar.Controllers
{
    public class ZReportController : Controller
    {
        private readonly ApplicationContext _applicationContext;
        private readonly UserManager<User> _userManager;
        private readonly ILoggerFactory _loggerFactory;
        private readonly GenerateErrorHelper _errorHelper;
        private readonly TokenValidationHelper _helper;

        public ZReportController(ApplicationContext applicationContext, UserManager<User> userManager,
            ILoggerFactory loggerFactory, GenerateErrorHelper errorHelper, TokenValidationHelper helper)
        {
            _applicationContext = applicationContext;
            _userManager = userManager;
            _loggerFactory = loggerFactory;
            _errorHelper = errorHelper;
            _helper = helper;
        }

        [HttpPost]
        public IActionResult Index(KkmRequest request)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.UserToken == request.Token);
            var oper = _applicationContext.Operators.FirstOrDefault(o => o.UserId == user.Id);
            var kkm = _applicationContext.Kkms.FirstOrDefault(k => k.SerialNumber == request.CashboxUniqueNumber);
            var shift = _applicationContext.Shifts.FirstOrDefault(s => s.KkmId == kkm.Id);
            shift.CloseDate = DateTime.Now;
            _applicationContext.Update(shift);
            _applicationContext.SaveChangesAsync();
            var shiftOperations = _applicationContext.ShiftOperations.Where(s => s.ShiftId == shift.Id);
            var org = _applicationContext.Orgs.FirstOrDefault(o => o.Id == oper.OrgId);
            var response = new XReportKkmResponse
            {
                Data = new Data
                {
                    Buy = new OperationTypeSummaryApiModel
                    {
                        Change = 0,
                        Taken = shiftOperations.Where(o => o.OperationType == OperationTypeEnum.OPERATION_BUY)
                            .Sum(o => o.TotalAmount),
                        VAT = 0,
                        TotalCount = shiftOperations.Where(o => o.OperationType == OperationTypeEnum.OPERATION_BUY)
                            .Sum(o => o.Count),
                        PaymentsByTypesApiModel = new List<PaymentsByTypesApiModel>(),
                        Discount = 0,
                        Markup = 0,
                        Count = 0
                    },
                    Sell = new OperationTypeSummaryApiModel
                    {
                        Change = 0,
                        Taken = shiftOperations.Where(o => o.OperationType == OperationTypeEnum.OPERATION_SELL)
                            .Sum(o => o.TotalAmount),
                        VAT = 0,
                        TotalCount = shiftOperations.Where(o => o.OperationType == OperationTypeEnum.OPERATION_SELL)
                            .Sum(o => o.Count),
                        PaymentsByTypesApiModel = new List<PaymentsByTypesApiModel>(),
                        Discount = 0,
                        Markup = 0,
                        Count = 0
                    },
                    ReturnBuy = new OperationTypeSummaryApiModel
                    {
                        Change = 0,
                        Taken = shiftOperations.Where(o => o.OperationType == OperationTypeEnum.OPERATION_BUY_RETURN)
                            .Sum(o => o.TotalAmount),
                        VAT = 0,
                        TotalCount = shiftOperations.Where(o => o.OperationType == OperationTypeEnum.OPERATION_BUY_RETURN)
                            .Sum(o => o.Count),
                        PaymentsByTypesApiModel = new List<PaymentsByTypesApiModel>(),
                        Discount = 0,
                        Markup = 0,
                        Count = 0
                    },
                    ReturnSell = new OperationTypeSummaryApiModel
                    {
                        Change = 0,
                        Taken = shiftOperations.Where(o => o.OperationType == OperationTypeEnum.OPERATION_SELL_RETURN)
                            .Sum(o => o.TotalAmount),
                        VAT = 0,
                        TotalCount = shiftOperations.Where(o => o.OperationType == OperationTypeEnum.OPERATION_SELL_RETURN)
                            .Sum(o => o.Count),
                        PaymentsByTypesApiModel = new List<PaymentsByTypesApiModel>(),
                        Discount = 0,
                        Markup = 0,
                        Count = 0
                    },
                    TaxPayerName = org.Name,
                    TaxPayerVAT = org.VAT,
                    TaxPayerIN = org.Inn,
                    TaxPayerVATNumber = org.VATNumber,
                    TaxPayerVATSeria = org.VATSeria,
                    CashboxIN = kkm.ReqNum,
                    CashboxSN = kkm.SerialNumber,
                    CashboxRN = kkm.FnsKkmId,
                    StartOn = shift.OpenDate,
                    CloseOn = shift.CloseDate,
                    ReportOn = DateTime.Now,
                    CashierCode = oper.Code,
                    ShiftNumber = shift.Number,
                    ControlSum = 1,
                    DocumentCount = shiftOperations.Count(),
                    OfflineMode = false,
                    ReportNumber = 1,
                    CashboxOfflineMode = false,
                    EndNonNullable = new NonNullableApiModel()
                    {
                        Buy = shift.SaldoEnd
                    },
                    StartNonNullable = new NonNullableApiModel()
                    {
                        Buy = shift.SaldoEnd
                    },
                    SumInCashbox = shift.KkmBalance,
                    PutMoneySum = 0,
                    TakeMoneySum = 0
                }
            };
            return Json(response);
        }
    }
}