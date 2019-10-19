using System;
using System.Linq;
using HSCFiscalRegistrar.Helpers;
using HSCFiscalRegistrar.OfdRequests;
using HSCFiscalRegistrar.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Models.DTO.XReport;
using Models.DTO.XReport.KkmResponse;
using Models.Enums;
using Newtonsoft.Json;
using DateTime = System.DateTime;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    public class XReportController : Controller
    {
        private readonly ApplicationContext _applicationContext;
        private readonly UserManager<User> _userManager;
        private readonly TokenValidationHelper _helper;
        private readonly ILoggerFactory _loggerFactory;
        private readonly GenerateErrorHelper _errorHelper;

        public XReportController(ApplicationContext applicationContext, UserManager<User> userManager,
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
            var logger = _loggerFactory.CreateLogger("XReport|Post");
            try
            {
                logger.LogInformation($"X-Отчет: {request.Token}");
                var user = _userManager.Users.FirstOrDefault(u => u.UserToken == request.Token);
                var kkm = _applicationContext.Kkms.FirstOrDefault(k => k.Id == user.KkmId);
                var shift = _applicationContext.Shifts.Last(s => s.KkmId == kkm.Id && s.CloseDate == DateTime.MinValue);
                var operations = _applicationContext.Operations.Where(o => o.ShiftId == shift.Id);
                var shiftOperations = ZxReportService.GetShiftOperations(operations, shift);
                ZxReportService.AddShiftProps(shift, operations);
                var response = new XReportKkmResponse(shiftOperations, operations, user, kkm, shift);
                if (kkm == null) return Json( _errorHelper.GetErrorRequest((int) ErrorEnums.NO_ACCESS_TO_CASH));
                kkm.ReqNum += 1;
                _applicationContext.ShiftOperations.AddRangeAsync(shiftOperations);
                _applicationContext.SaveChangesAsync();
                var xReportOfdRequest = new OfdXReport(_loggerFactory);
                xReportOfdRequest.Request(kkm, user);

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