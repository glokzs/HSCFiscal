using System;
using System.Threading.Tasks;
using HSCFiscalRegistrar.DTO.Registration;
using HSCFiscalRegistrar.Enums;
using HSCFiscalRegistrar.Helpers;
using HSCFiscalRegistrar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ILoggerFactory = Microsoft.Extensions.Logging.ILoggerFactory;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILoggerFactory _loggerFactory;
        private readonly GenerateErrorHelper _errorHelper;

        public RegistrationController(UserManager<User> userManager, 
            SignInManager<User> signInManager,
            ILoggerFactory loggerFactory, 
            GenerateErrorHelper errorHelper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _loggerFactory = loggerFactory;
            _errorHelper = errorHelper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserRegistration model)
        {
            var logger = _loggerFactory.CreateLogger("Registration|Post");
            
            try
            {
                logger.LogInformation($"Регистрация пользователя: {model}");
                if (ModelState.IsValid)
                {
                    if (model.Login.Contains("@"))
                    {
                        User user = new User
                        {
                            Email = model.Login,
                            UserName = model.Login,
                            UserToken = GenerateUserToken.GetGuidKey(),
                            DateTimeCreationToken = GenerateUserToken.TimeCreation()
                        };

                        var result = await _userManager.CreateAsync(user, model.Password);

                        if (result.Succeeded)
                        {
                            await _signInManager.SignInAsync(user, false);
                            ResponseServerReg answer = new ResponseServerReg
                            {
                                Successful = "You are registered",
                                Token = user.UserToken.ToString()
                            };

                            return Json(answer);
                        }

                        logger.LogError($"Неверный логин: {model.Login}");
                        return Ok(_errorHelper.GetErrorRequest((int)ErrorEnums.AUTHORIZATION_ERROR));
                    }
                    else
                    {
                        logger.LogError($"Неверный формат логина: {model.Login}");
                        return Ok(_errorHelper.GetErrorRequest((int)ErrorEnums.UNKNOWN_ERROR));
                    }
                }

                logger.LogError($"Ошибка регистрации пользователя: {model.Login} {model.Password}");
                return Ok(_errorHelper.GetErrorRequest((int)ErrorEnums.UNKNOWN_ERROR));
            }
            catch (Exception e)
            {
                logger.LogError(e.ToString());
                var str = "Invalid Error";
                return Json(str);
            }
        }
    }
}