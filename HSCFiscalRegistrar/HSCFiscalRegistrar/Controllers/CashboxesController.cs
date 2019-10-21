using System;
using System.Collections.Generic;
using System.Linq;
using HSCFiscalRegistrar.Exceptions;
using HSCFiscalRegistrar.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using Models.DTO.Cashboxes;
using Models.Enums;
using Newtonsoft.Json;
using ILoggerFactory = Microsoft.Extensions.Logging.ILoggerFactory;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashboxesController : Controller
    {
        private readonly ApplicationContext _applicationContext;
        private readonly UserManager<User> _userManager;
        private readonly TokenValidationHelper _validationHelper;
        private readonly GenerateErrorHelper _errorHelper;
        private readonly ILoggerFactory _loggerFactory;

        public CashboxesController(TokenValidationHelper helper,
            ILoggerFactory loggerFactory, GenerateErrorHelper errorHelper, UserManager<User> userManager,
            ApplicationContext applicationContext)
        {
            _validationHelper = helper;
            _loggerFactory = loggerFactory;
            _errorHelper = errorHelper;
            _userManager = userManager;
            _applicationContext = applicationContext;
        }

        [HttpPost]
        public ActionResult Get([FromBody] DtoToken dtoToken)
        {
            var logger = _loggerFactory.CreateLogger("Cashbox|Post");
            try
            {
                logger.LogInformation($"Получение списка касс пользователя: {dtoToken.Token}");

                var caseError = _validationHelper.TokenValidator(_userManager, dtoToken.Token);

                if (caseError == 0) return GetCashBoxesData();
                return Json(_errorHelper.GetErrorRequest((int) caseError));
            }
            catch (UserNullException)
            {
                return Ok(_errorHelper.GetErrorRequest((int) ErrorEnums.UNKNOWN_ERROR));
            }
            catch (Exception e)
            {
                logger.LogError($"Неизвестная ошибка: {e.StackTrace}");
                return Ok(_errorHelper.GetErrorRequest((int) ErrorEnums.UNKNOWN_ERROR));
            }
        }

        private OkObjectResult GetCashBoxesData()
        {
            var user = _userManager.GetUserAsync(User);
            var kkm = _applicationContext.Kkms.First(k => k.UserId == user.Result.Id);
            var shiftNumber = 1;
            if (_applicationContext.Shifts.Any(s => s.KkmId == kkm.Id))
            {
                shiftNumber = _applicationContext.Shifts.Last().Number;
            }
            var wrapper = new Wrapper
            {
                Data = new Data
                {
                    List = new List<List>
                    {
                        new List
                        {
                            UniqueNumber = kkm.SerialNumber,
                            RegistrationNumber = kkm.FnsKkmId,
                            IdentificationNumber = kkm.DeviceId.ToString(),
                            Name = kkm.Name,
                            IsOffline = false,
                            CurrentStatus = 1,
                            Shift = shiftNumber
                        }
                    }
                }
            };
            return Ok(JsonConvert.SerializeObject(wrapper));
        }
    }
}