using System;
using System.Linq;
using System.Threading.Tasks;
using HSCFiscalRegistrar.Helpers;
using HSCFiscalRegistrar.OfdRequests;
using HSCFiscalRegistrar.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Models.DTO.XReport;
using Models.DTO.XReport.KkmResponse;
using Newtonsoft.Json;
using Npgsql.EntityFrameworkCore.PostgreSQL.ValueGeneration.Internal;
using DateTime = System.DateTime;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    public class XReportController : Controller
    {
        private readonly ApplicationContext _applicationContext;
        private readonly UserManager<User> _userManager;
        private readonly ILoggerFactory _loggerFactory;
        private readonly GenerateErrorHelper _errorHelper;

        public XReportController(ApplicationContext applicationContext, UserManager<User> userManager,
            ILoggerFactory loggerFactory, GenerateErrorHelper errorHelper)
        {
            _applicationContext = applicationContext;
            _userManager = userManager;
            _loggerFactory = loggerFactory;
            _errorHelper = errorHelper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] KkmRequest request)
        {
            var logger = _loggerFactory.CreateLogger("XReport|Post");
            try
            {
                logger.LogInformation($"X-Отчет: {request.Token}");
                var user = _userManager.Users.FirstOrDefault(u => u.UserToken == request.Token);
                var kkm = _applicationContext.Kkms.FirstOrDefault(k => k.Id == user.KkmId);
                var merch = _userManager.Users.FirstOrDefault(u => user.OwnerId == u.Id);
                Shift shift;
                try
                {
                    shift = _applicationContext.Shifts.Last(s => s.KkmId == kkm.Id && s.CloseDate == DateTime.MinValue);
                }
                catch (Exception)
                {
                    shift = await GetShift(user,kkm);
                }
                
                var operations = _applicationContext.Operations.Where(o => o.ShiftId == shift.Id);
                var shiftOperations = ZxReportService.GetShiftOperations(operations, shift);
                ZxReportService.AddShiftProps(shift, operations);
                var response = new XReportKkmResponse(shiftOperations, operations, merch, kkm, shift);
                if (kkm == null) return Json( _errorHelper.GetErrorRequest(3));
                kkm.ReqNum += 1;
                await _applicationContext.ShiftOperations.AddRangeAsync(shiftOperations);
                await _applicationContext.SaveChangesAsync();
                var xReportOfdRequest = new OfdXReport(_loggerFactory);
                xReportOfdRequest.Request(kkm, merch);

                return Ok(JsonConvert.SerializeObject(response));
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                return Json(e.Message);
            }
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

    }
}