using System;
using System.Collections.Generic;
using System.Linq;
using HSCFiscalRegistrar.DTO.XReport;
using HSCFiscalRegistrar.DTO.XReport.KkmResponse;
using HSCFiscalRegistrar.Enums;
using HSCFiscalRegistrar.Helpers;
using HSCFiscalRegistrar.Models;
using HSCFiscalRegistrar.OfdRequests;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using DateTime = System.DateTime;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    public class ZReportController : Controller
    {
        private readonly ApplicationContext _applicationContext;
        private readonly UserManager<User> _userManager;
        private readonly TokenValidationHelper _helper;
        private readonly ILoggerFactory _loggerFactory;
        private readonly GenerateErrorHelper _errorHelper;

        public ZReportController(ApplicationContext applicationContext, UserManager<User> userManager,
            ILoggerFactory loggerFactory, TokenValidationHelper helper, GenerateErrorHelper errorHelper)
        {
            _applicationContext = applicationContext;
            _userManager = userManager;
            _loggerFactory = loggerFactory;
            _helper = helper;
            _errorHelper = errorHelper;
        }

        [HttpPost]
        public IActionResult Post([FromBody] KkmRequest request)
        {
            var logger = _loggerFactory.CreateLogger("ZReport|Post");
            try
            {
                logger.LogInformation($"Z-Отчет: {request.Token}");
                var user = _userManager.Users.FirstOrDefault(u => u.UserToken == request.Token);
                var oper = _applicationContext.Operators.FirstOrDefault(o => o.UserId == user.Id);
                var kkm = _applicationContext.Kkms.FirstOrDefault(k => k.Id == oper.KkmId);
                var shift = _applicationContext.Shifts.Last(s => s.KkmId == kkm.Id && s.CloseDate == DateTime.MinValue);
                var operations = _applicationContext.Operations.Where(o => o.ShiftId == shift.Id);
                var org = _applicationContext.Orgs.FirstOrDefault(o => o.Id == oper.OrgId);
                var shiftOperations = GetShiftOperations(operations, shift);
                AddShiftProps(shift, operations);
                CloseShift(true, shift);
                var response = new XReportKkmResponse(shiftOperations, operations, org, kkm, shift, oper);
                _applicationContext.ShiftOperations.AddRangeAsync(shiftOperations);
                _applicationContext.SaveChangesAsync();
                var ofdShiftClose = new OfdShiftClose(_loggerFactory);
                ofdShiftClose.Request(kkm, org, shift.Number);
                return Ok(JsonConvert.SerializeObject(response));
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return Json(e.Message);
            }
        }

        private void AddShiftProps(Shift shift, IQueryable<Operation> operations)
        {
            shift.BuySaldoEnd = shift.BuySaldoBegin +
                                operations.Where(o => o.Type == OperationTypeEnum.OPERATION_BUY).Sum(o => o.Amount);
            shift.SellSaldoEnd = shift.SellSaldoBegin +
                                 operations.Where(o => o.Type == OperationTypeEnum.OPERATION_SELL)
                                     .Sum(o => o.Amount);
            shift.RetunSellSaldoEnd = shift.RetunSellSaldoBegin + operations
                                          .Where(o => o.Type == OperationTypeEnum.OPERATION_SELL_RETURN)
                                          .Sum(o => o.Amount);
            shift.RetunBuySaldoEnd = shift.RetunBuySaldoBegin +
                                     operations.Where(o => o.Type == OperationTypeEnum.OPERATION_BUY)
                                         .Sum(o => o.Amount);
            CalculateBalance(shift, operations);
        }

        private static void CalculateBalance(Shift shift, IQueryable<Operation> operations)
        {
            shift.KkmBalance = operations
                                   .Where(o => o.Type == OperationTypeEnum.OPERATION_SELL)
                                   .Sum(o => o.Amount) +
                               operations
                                   .Where(o => o.Type == OperationTypeEnum.OPERATION_BUY_RETURN)
                                   .Sum(o => o.Amount) +
                               shift.SellSaldoBegin +
                               shift.RetunBuySaldoBegin -
                               operations.Where(o => o.Type == OperationTypeEnum.OPERATION_BUY)
                                   .Sum(o => o.Amount) -
                               operations.Where(o => o.Type == OperationTypeEnum.OPERATION_SELL_RETURN)
                                   .Sum(o => o.Amount) - shift.RetunBuySaldoBegin - shift.RetunSellSaldoBegin;
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

        private void CloseShift(bool isClose, Shift shift)
        {
            if (isClose)
            {
                shift.CloseDate = DateTime.Now;
            }
        }
    }
}