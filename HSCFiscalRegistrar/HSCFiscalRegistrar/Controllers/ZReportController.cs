using System;
using System.Linq;
using System.Threading.Tasks;
using HSCFiscalRegistrar.Helpers;
using HSCFiscalRegistrar.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO.CloseShift;
using Models.DTO.CloseShift.OfdResponse;
using Models.DTO.XReport;
using Models.DTO.XReport.KkmResponse;
using Models.Services;
using Newtonsoft.Json;
using Serilog;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    public class ZReportController : Controller
    {
        private readonly ApplicationContext _applicationContext;
        private readonly UserManager<User> _userManager;
        private readonly GenerateErrorHelper _errorHelper;

        public ZReportController(ApplicationContext applicationContext, UserManager<User> userManager, GenerateErrorHelper errorHelper)
        {
            _applicationContext = applicationContext;
            _userManager = userManager;
            _errorHelper = errorHelper;
        }

        [HttpPost]
        public IActionResult Post([FromBody] KkmRequest request)
        {
            try
            {
                Log.Information("ZReport|Post");
                Log.Information($"Z-Отчет: {request.Token}");
                
                var user = _userManager.Users.FirstOrDefault(u => u.UserToken == request.Token);
                var kkm = _applicationContext.Kkms.FirstOrDefault(k => k.Id == user.KkmId);
                var shift = _applicationContext.Shifts.Last(s => s.KkmId == kkm.Id);
                var operations = _applicationContext.Operations.Where(o => o.ShiftId == shift.Id);
                var shiftOperations = ZxReportService.GetShiftOperations(operations, shift);
                ZxReportService.AddShiftProps(shift, operations);
                ZxReportService.CloseShift(true, shift);
                var merch = _userManager.Users.FirstOrDefault(u => u.Id == kkm.UserId);
                var closeShiftOfdResponse = OfdRequest(kkm, merch, shift.Number);
                if (kkm == null) return Json(_errorHelper.GetErrorRequest(3));
                kkm.OfdToken = closeShiftOfdResponse.Result.Token;
                kkm.ReqNum += 1;
                var response = new XReportKkmResponse(shiftOperations, operations, merch, kkm, shift);
                _applicationContext.ShiftOperations.AddRangeAsync(shiftOperations);
                _applicationContext.SaveChangesAsync();
                return Ok(JsonConvert.SerializeObject(response));
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
                return Json(e.Message);
            }
        }

        private async Task<CloseShiftOfdResponse> OfdRequest(Kkm kkm, User org, int shiftNumber)
        {
            
            var closeShiftRequest = new CloseShiftRequest(kkm, org, shiftNumber);
            try
            {
                Log.Information("OfdCloseShiftRequest|Post");
                Log.Information("Отправка запроса на закрытие смены в ОФД");
                await HttpService.Post(closeShiftRequest);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
            }

            var x = await HttpService.Post(closeShiftRequest);
            string json = JsonConvert.SerializeObject(x);
            var response = JsonConvert.DeserializeObject<CloseShiftOfdResponse>(json);
            return response;
        }
    }
}