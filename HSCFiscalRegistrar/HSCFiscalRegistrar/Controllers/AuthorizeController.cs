using System;
using System.Linq;
using System.Threading.Tasks;
using HSCFiscalRegistrar.Exceptions;
using HSCFiscalRegistrar.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using Models;
using Models.DTO.Auth;
using Models.DTO.UserModel;
using Serilog;
using ILoggerFactory = Microsoft.Extensions.Logging.ILoggerFactory;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthorizeController(UserManager<User> userManager, 
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDTO model)
        {
            try
            {
                Log.Information("Autorize|Post");
                Log.Information($"Авторизация пользователя: {model}");
                
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

                        if (!response.Succeeded) throw new DbUpdateException("Ошибка обновления дб");
                        var dto = new AnswerServerAuth
                        {
                            Data = new Data
                            {
                                Token = appUser.UserToken
                            }
                        };
                        return Ok(JsonConvert.SerializeObject(dto));
                    }
                }

                Log.Error($"Ошибка авторизации пользователя: {model.Login}");
                throw new AuthorizeException("Неверный логин или пароль");
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
                return Ok(e.Message);
            }

        }
    }
}