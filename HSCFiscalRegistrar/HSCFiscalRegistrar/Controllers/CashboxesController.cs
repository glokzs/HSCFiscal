using System;
using System.Collections.Generic;
using HSCFiscalRegistrar.DTO.Cashboxes;
using HSCFiscalRegistrar.Enums;
using HSCFiscalRegistrar.Exceptions;
using HSCFiscalRegistrar.Helpers;
using HSCFiscalRegistrar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ILoggerFactory = Microsoft.Extensions.Logging.ILoggerFactory;


namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashboxesController : Controller
    {
        private static UserManager<User> _userManager;
        private readonly ApplicationContext _context;
        private readonly TokenValidationHelper _validationHelper;
        private readonly GenerateErrorHelper _errorHelper;
        private readonly ILoggerFactory _loggerFactory;

        public CashboxesController(UserManager<User> userManager, TokenValidationHelper helper,
            ILoggerFactory loggerFactory, ApplicationContext context, GenerateErrorHelper errorHelper)
        {
            _userManager = userManager;
            _validationHelper = helper;
            _loggerFactory = loggerFactory;
            _context = context;
            _errorHelper = errorHelper;
        }

        [HttpPost]
        public ActionResult Get([FromBody] DtoToken dtoToken)
        {
            var logger = _loggerFactory.CreateLogger("Cashbox|Post");
            

            try
            {
                logger.LogInformation($"Получение списка касс пользователя: {dtoToken.Token}");
                var error = _validationHelper.TokenValidator(_context, dtoToken.Token);
                return error == null ? GetCashBoxesData() : throw error;
            }
            catch (UserNullException e)
            {
                return Ok(_errorHelper.GetErrorRequest((int)ErrorEnums.UNKNOWN_ERROR));
            }
            catch (Exception e)
            {
                logger.LogError($"Неизвестная ошибка: {e.StackTrace}");
                return Ok(_errorHelper.GetErrorRequest((int)ErrorEnums.UNKNOWN_ERROR));
            }
        }

        private OkObjectResult GetCashBoxesData()
        {
            Wrapper wrapper = new Wrapper
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