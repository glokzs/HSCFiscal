using System;
using System.Collections.Generic;
using HSCFiscalRegistrar.DTO.Cashboxes;
using HSCFiscalRegistrar.DTO.Errors;
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
        private readonly ApplicationContext _context;
        private readonly TokenValidationHelper _helper;
        private readonly ILoggerFactory _loggerFactory;
        private ILogger Logger { get; set; }

        public CashboxesController(
            TokenValidationHelper helper,
            ILoggerFactory loggerFactory,
            ApplicationContext context)
        {
            _helper = helper;
            _loggerFactory = loggerFactory;
            _context = context;
            Logger = this._loggerFactory.CreateLogger("Cashbox|Post");
        }

        [HttpPost]
        public ActionResult Get([FromBody] DtoToken dtoToken)
        {
            try
            {
                Logger.LogInformation($"Получение списка касс пользователя: {dtoToken.Token}");
                var error = _helper.TokenValidator(_context, dtoToken.Token);

                return GetCashBoxesData();
            }
            catch (Exception)
            {
                Logger = _loggerFactory.CreateLogger("Cashbox|Post");
                Logger.LogError($"Неверный токен: {dtoToken.Token}");
                return Ok(ErrorsAuth.TokenError());
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