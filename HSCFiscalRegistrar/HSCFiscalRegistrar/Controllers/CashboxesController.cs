using System;
using System.Collections.Generic;
using System.Linq;
using HSCFiscalRegistrar.DTO.Cashboxes;
using HSCFiscalRegistrar.DTO.Errors;
using HSCFiscalRegistrar.Helpers;
using HSCFiscalRegistrar.Models;
using HSCFiscalRegistrar.Models.APKInfo;
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
        private readonly TokenValidationHelper _helper;
        private readonly ILoggerFactory _loggerFactory;
        public CashboxesController(UserManager<User> userManager, TokenValidationHelper helper, ILoggerFactory loggerFactory, ApplicationContext context)
        {
            _userManager = userManager;
            _helper = helper;
            _loggerFactory = loggerFactory;
            _context = context;
        }
        
        [HttpPost]
        public  ActionResult Get([FromBody] DtoToken dtoToken)
        {
            var _logger = _loggerFactory.CreateLogger("Cashbox|Post");
            _logger.LogInformation($"Получение списка касс пользователя: {dtoToken.Token}"); 
            
            var error = _helper.TokenValidator(_context, dtoToken.Token);

            User resUser = _userManager.Users.FirstOrDefault(t => t.UserToken == dtoToken.Token);
            if (resUser != null)
            {
                Operator resOperator = _context.Operators.FirstOrDefault(i => i.UserId == resUser.Id);
                if (resOperator != null)
                {
                    Kkm resKkm = _context.Kkms.FirstOrDefault(i => i.Id == resOperator.KkmId);
                    if (resKkm != null)
                    {
                        return error == null ? GetCashBoxesData(resKkm) : throw error;
                    }
                }
            }
            else
            {
                _logger.LogError($"Неверный токен: {dtoToken.Token}");
                return Ok(ErrorsAuth.TokenError());
            }
                
            

            return Ok();
        }
            
        private OkObjectResult GetCashBoxesData(Kkm kkm)
        {
            Wrapper wrapper = new Wrapper
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