using System;
using System.Collections.Generic;
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
        private readonly UserManager<User> _userManager;
        private readonly TokenValidationHelper _validationHelper;
        private readonly GenerateErrorHelper _errorHelper;
        private readonly ILoggerFactory _loggerFactory;

        public CashboxesController(TokenValidationHelper helper,
            ILoggerFactory loggerFactory, GenerateErrorHelper errorHelper, UserManager<User> userManager)
        {
            _validationHelper = helper;
            _loggerFactory = loggerFactory;
            _errorHelper = errorHelper;
            _userManager = userManager;
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
            var wrapper = new Wrapper
            {
                Data = new Data
                {
                    List = new List<List>
                    {
                        new List
                        {
                            UniqueNumber = "SWK00030767",
                            RegistrationNumber = "240820180008",
                            IdentificationNumber = "2405",
                            Name = "Касса - 212408",
                            IsOffline = false,
                            CurrentStatus = 1,
                            Shift = 59
                        }
                    }
                }
            };
            return Ok(JsonConvert.SerializeObject(wrapper));
        }
    }
}