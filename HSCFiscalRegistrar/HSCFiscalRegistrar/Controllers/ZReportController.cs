using System;
using System.Collections.Generic;
using System.Linq;
using HSCFiscalRegistrar.DTO.XReport;
using HSCFiscalRegistrar.DTO.XReport.KkmResponse;
using HSCFiscalRegistrar.Enums;
using HSCFiscalRegistrar.Helpers;
using HSCFiscalRegistrar.Models;
using HSCFiscalRegistrar.OfdRequests;
using HSCFiscalRegistrar.Services;
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
                var shiftOperations = ZxReportService.GetShiftOperations(operations, shift);
                ZxReportService.AddShiftProps(shift, operations);
                ZxReportService.CloseShift(true, shift);
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

        
    }
}