using System;
using System.Linq;
using System.Threading.Tasks;
using HSCFiscalRegistrar.Helpers;
using HSCFiscalRegistrar.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Models.DTO.CloseShift;
using Models.DTO.CloseShift.OfdResponse;
using Models.DTO.XReport;
using Models.DTO.XReport.KkmResponse;
using Models.Enums;
using Models.Services;
using Newtonsoft.Json;

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
                var kkm = _applicationContext.Kkms.FirstOrDefault(k => k.UserId == user.Id);
                var shift = _applicationContext.Shifts.Last(s => s.KkmId == kkm.Id);
                var operations = _applicationContext.Operations.Where(o => o.ShiftId == shift.Id);
                var shiftOperations = ZxReportService.GetShiftOperations(operations, shift);
                ZxReportService.AddShiftProps(shift, operations);
                ZxReportService.CloseShift(true, shift);
                var merch = _userManager.Users.FirstOrDefault(u => u.Id == kkm.UserId);
                var closeShiftOfdResponse = OfdRequest(kkm,merch,shift.Number);
                if (kkm == null) return Json(_errorHelper.GetErrorRequest((int) ErrorEnums.NO_ACCESS_TO_CASH));
                kkm.OfdToken = closeShiftOfdResponse.Result.Token;
                kkm.ReqNum += 1;
                var response = new XReportKkmResponse(shiftOperations, operations, user, kkm, shift);
                _applicationContext.ShiftOperations.AddRangeAsync(shiftOperations);
                _applicationContext.SaveChangesAsync();
                return Ok(JsonConvert.SerializeObject(response));
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return Json(e.Message);
            }

            
        }
        
        private async Task<CloseShiftOfdResponse> OfdRequest(Kkm kkm, User org, int shiftNumber)
        {
            
            var logger = _loggerFactory.CreateLogger("OfdCloseShiftRequest|Post");
            var closeShiftRequest = new CloseShiftRequest(kkm, org, shiftNumber);
            try
            {
                logger.LogInformation("Отправка запроса на закрытие смены в ОФД");
                await HttpService.Post(closeShiftRequest);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }
            var x = await HttpService.Post(closeShiftRequest);
            string json = JsonConvert.SerializeObject(x);
            var response = JsonConvert.DeserializeObject<CloseShiftOfdResponse>(json);
            return response;
        }

        
    }
}