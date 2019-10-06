using System;
using System.Linq;
using System.Threading.Tasks;
using HSCFiscalRegistrar.DTO.Errors;
using HSCFiscalRegistrar.DTO.Registration;
using HSCFiscalRegistrar.DTO.UserModel;
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
    public class ChangePasswordController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILoggerFactory _loggerFactory;

        public ChangePasswordController(UserManager<User> userManager, ILoggerFactory loggerFactory,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _loggerFactory = loggerFactory;
        }

        [HttpPost]
        public async Task<JsonResult> Post([FromBody] UserChangePassword model)
        {
            var _logger = _loggerFactory.CreateLogger("ChangePassword|Post");
            _logger.LogInformation($"Смена пароля: {model}");

            try
            {
                var result = await _signInManager.PasswordSignInAsync(model.Login,
                    model.Password,
                    false,
                    false);

                if (result.Succeeded)
                {
                    User user = _userManager.Users.FirstOrDefault(r => r.UserName == model.Login);

                    if (user != null && user.UserToken.ToString() == model.Token)
                    {
                        user.DateTimeCreationToken = GenerateUserToken.TimeCreation();
                        user.UserToken = GenerateUserToken.GetGuidKey();

                        if (model.Password == model.NewPassword)
                        {
                            return Json(ErrorsAuth.PasswordAlready());
                        }

                        await _userManager.ChangePasswordAsync(user, model.Password, model.NewPassword);

                        IdentityResult response = await _userManager.UpdateAsync(user);

                        if (response.Succeeded)
                        {
                            ResponseServerReg answer = new ResponseServerReg
                            {
                                Successful = "Password changed successfully",
                                Token = user.UserToken.ToString()
                            };

                            return Json(answer);
                        }

                        return Json("Errors system");
                    }

                    return Json(ErrorsAuth.UserNotFound());
                }

                _logger.LogError($"Такого пользователя не существует: {model.Login}");
                return Json(ErrorsAuth.UserNotFound());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Json(ErrorsAuth.LoginError());
            }
        }
    }
}