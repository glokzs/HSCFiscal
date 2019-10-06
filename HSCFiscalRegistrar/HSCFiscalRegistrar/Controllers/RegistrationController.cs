using System;
using System.Threading.Tasks;
using HSCFiscalRegistrar.DTO.Errors;
using HSCFiscalRegistrar.DTO.Registration;
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

        public RegistrationController(UserManager<User> userManager, SignInManager<User> signInManager,
            ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _loggerFactory = loggerFactory;
        }

        [HttpPost]
        public async Task<JsonResult> Post([FromBody] UserRegistration model)
        {
            var _logger = _loggerFactory.CreateLogger("Registration|Post");
            _logger.LogInformation($"Регистрация пользователя: {model}");

            try
            {
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

                        _logger.LogError($"Неверный логин: {model.Login}");
                        return Json(ErrorsAuth.CheckLogin());
                    }
                    else
                    {
                        _logger.LogError($"Неверный формат логина: {model.Login}");
                        return Json(ErrorsAuth.RegisterError());
                    }
                }

                _logger.LogError($"Ошибка регистрации пользователя: {model.Login} {model.Password}");
                return Json(ErrorsAuth.RegisterError());
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                var str = "Invalid Error";
                return Json(str);
            }
        }
    }
}