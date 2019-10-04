using System;
using System.Linq;
using System.Threading.Tasks;
using HSCFiscalRegistrar.DTO.Auth;
using HSCFiscalRegistrar.DTO.Errors;
using HSCFiscalRegistrar.DTO.UserModel;
using HSCFiscalRegistrar.Helpers;
using HSCFiscalRegistrar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using ILoggerFactory = Microsoft.Extensions.Logging.ILoggerFactory;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILoggerFactory _loggerFactory;

        public AuthorizeController(UserManager<User> userManager, ILoggerFactory loggerFactory,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _loggerFactory = loggerFactory;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDTO model)
        {
            var _logger = _loggerFactory.CreateLogger("Autorize|Post");
            
            try
            {
                _logger.LogInformation($"Авторизация пользователя: {model}");
                
                var result = await _signInManager.PasswordSignInAsync(model.Login,
                    model.Password,
                    false,
                    false);

                if (result.Succeeded)
                {
                    var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Login);

                    if (appUser != null)
                    {
                        appUser.DateTimeCreationToken = GenerateUserToken.TimeCreation();
                        appUser.ExpiryDate = GenerateUserToken.ExpiryDate();
                        appUser.UserToken = GenerateUserToken.Token(appUser.Id);
                        var response = await _userManager.UpdateAsync(appUser);

                        if (response.Succeeded)
                        {
                            var dto = new AnswerServerAuth
                            {
                                Data = new Data
                                {
                                    Token = appUser.UserToken.ToString()
                                }
                            };

                            return Ok(JsonConvert.SerializeObject(dto));
                        }
                        else
                        {
                            return Ok("Ошибка в системе!");
                        }
                    }
                    else
                    {
                        return Ok(ErrorsAuth.LoginError());
                    }
                }
                else
                {
                    _logger.LogError($"Ошибка авторизации пользователя: {model.Login}");
                    return Ok(ErrorsAuth.LoginError());
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                return Ok(e.Message);
            }
            
        }
    }
}