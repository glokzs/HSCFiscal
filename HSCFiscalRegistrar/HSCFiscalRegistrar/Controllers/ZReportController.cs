using System.Collections.Generic;
using System.Linq;
using Castle.Core.Logging;
using HSCFiscalRegistrar.DTO.XReport;
using HSCFiscalRegistrar.DTO.XReport.KkmResponce;
using HSCFiscalRegistrar.Enums;
using HSCFiscalRegistrar.Helpers;
using HSCFiscalRegistrar.Models;
using HSCFiscalRegistrar.Models.APKInfo;
using HSCFiscalRegistrar.Models.Operation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DateTime = System.DateTime;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    public class ZReportController : Controller
    {
        private readonly ApplicationContext _applicationContext;
        private readonly UserManager<User> _userManager;
        private readonly GenerateErrorHelper _errorHelper;
        private readonly TokenValidationHelper _helper;

        public ZReportController(ApplicationContext applicationContext, UserManager<User> userManager,
            GenerateErrorHelper errorHelper, TokenValidationHelper helper)
        {
            _applicationContext = applicationContext;
            _userManager = userManager;
            _errorHelper = errorHelper;
            _helper = helper;
        }

        [HttpPost]
        public IActionResult Post([FromBody] KkmRequest request)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.UserToken == request.Token);
            var oper = _applicationContext.Operators.FirstOrDefault(o => o.UserId == user.Id);
            var kkm = _applicationContext.Kkms.FirstOrDefault(k => k.Id == oper.KkmId);
            var shift = _applicationContext.Shifts.Last(s => s.KkmId == kkm.Id);
            var operations = _applicationContext.Operations.Where(o => o.ShiftId == shift.Id);
            var org = _applicationContext.Orgs.FirstOrDefault(o => o.Id == oper.OrgId);
            var shiftOperations = GetShiftOperations(operations, shift);
            AddShiftProps(shift, operations);
            var response = GetXReportKkmResponse(shiftOperations, operations, org, kkm, shift, oper);
            _applicationContext.ShiftOperations.AddRangeAsync(shiftOperations);
            _applicationContext.SaveChangesAsync();
            return Json(response);
        }

        private void AddShiftProps(Shift shift, IQueryable<Operation> operations)
        {
            if (shift != null && shift.CloseDate == DateTime.MinValue)
            {
                shift.CloseDate = DateTime.Now;
                shift.SaldoEnd = shift.SaldoBegin + operations.Sum(o => o.Amount);
            }
            else
            {
                shift.CloseDate = DateTime.Now;
                shift.SaldoEnd = operations.Sum(o => o.Amount);
            }
        }

        private XReportKkmResponse GetXReportKkmResponse(List<ShiftOperation> shiftOperations, IQueryable<Operation> operations,
            Org org, Kkm kkm, Shift shift, Operator oper)
        {
            return new XReportKkmResponse
            {
                Data = new Data
                {
                    Buy = GetOperation(shiftOperations, OperationTypeEnum.OPERATION_BUY),
                    Sell = GetOperation(shiftOperations, OperationTypeEnum.OPERATION_SELL),
                    ReturnBuy = GetOperation(shiftOperations, OperationTypeEnum.OPERATION_BUY_RETURN),
                    ReturnSell = GetOperation(shiftOperations, OperationTypeEnum.OPERATION_SELL_RETURN),
                    TaxPayerName = org.Name,
                    TaxPayerVAT = org.VAT,
                    TaxPayerIN = org.Inn,
                    TaxPayerVATNumber = org.VATNumber,
                    TaxPayerVATSeria = org.VATSeria,
                    CashboxIN = kkm.DeviceId,
                    CashboxSN = kkm.SerialNumber,
                    CashboxRN = kkm.FnsKkmId,
                    StartOn = shift.OpenDate,
                    CloseOn = shift.CloseDate,
                    ReportOn = DateTime.Now,
                    CashierCode = oper.Code,
                    ShiftNumber = shift.Number,
                    ControlSum = 1,
                    DocumentCount = operations.Count(),
                    OfflineMode = false,
                    ReportNumber = 1,
                    CashboxOfflineMode = false,
                    EndNonNullable = new NonNullableApiModel()
                    {
                        Sell = shift.SaldoEnd
                    },
                    StartNonNullable = new NonNullableApiModel()
                    {
                        Sell = shift.SaldoBegin
                    },
                    SumInCashbox = shift.KkmBalance,
                    PutMoneySum = 0,
                    TakeMoneySum = 0
                }
            };
        }

        private OperationTypeSummaryApiModel GetOperation(List<ShiftOperation> shiftOperations,  OperationTypeEnum type)
        {
            return new OperationTypeSummaryApiModel
            {
                Change = shiftOperations.Where(o => o.OperationType == type).Sum(o => o.Change),
                Taken = shiftOperations.Where(o => o.OperationType == type)
                    .Sum(o => o.TotalAmount),
                VAT = 0,
                TotalCount = shiftOperations.Where(o => o.OperationType == type)
                    .Sum(o => o.Count),
                PaymentsByTypesApiModel = new List<PaymentsByTypesApiModel>(),
                Discount = 0,
                Markup = 0,
                Count = 0
            };
        }

        private List<ShiftOperation> GetShiftOperations(IQueryable<Operation> operations, Shift shift)
        {
            var shiftOperations = new List<ShiftOperation>
            {
                GetShiftOperation(operations, shift, OperationTypeEnum.OPERATION_BUY),
                GetShiftOperation(operations, shift, OperationTypeEnum.OPERATION_SELL),
                GetShiftOperation(operations, shift, OperationTypeEnum.OPERATION_BUY_RETURN),
                GetShiftOperation(operations, shift, OperationTypeEnum.OPERATION_SELL_RETURN)
            };
            return shiftOperations;
        }

        private ShiftOperation GetShiftOperation(IQueryable<Operation> operations, Shift shift, OperationTypeEnum type)
        {
            return new ShiftOperation
            {
                OperationType = type,
                CardAmount = operations
                    .Where(o => o.Type == type)
                    .Sum(o => o.CardAmount),
                CashAmount = operations
                    .Where(o => o.Type == type)
                    .Sum(o => o.CashAmount),
                Count = operations.Count(o => o.Type == type),
                ShiftId = shift.Id,
                TotalAmount = operations
                    .Where(o => o.Type == type)
                    .Sum(o => o.Amount),
                Change = operations.Where(o => o.Type == type).Sum(o => o.ChangeAmount)
            };
        }
    }
}