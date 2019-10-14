using System;
using System.Linq;
using System.Threading.Tasks;
using HSCFiscalRegistrar.DTO.Registration;
using HSCFiscalRegistrar.DTO.UserModel;
using HSCFiscalRegistrar.Enums;
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
    public class ChangePasswordController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly GenerateErrorHelper _errorHelper;
        private readonly ILoggerFactory _loggerFactory;

        public ChangePasswordController(UserManager<User> userManager, ILoggerFactory loggerFactory,
            SignInManager<User> signInManager, GenerateErrorHelper errorHelper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _errorHelper = errorHelper;
            _loggerFactory = loggerFactory;
        }

        [HttpPost]
        public async Task<OkObjectResult> Post([FromBody] UserChangePassword model)
        {
            var _logger = _loggerFactory.CreateLogger("ChangePassword|Post");
            

            try
            {
                _logger.LogInformation($"Смена пароля: {model}");
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
                            return Ok(_errorHelper.GetErrorRequest((int)ErrorEnums.AUTHORIZATION_ERROR));
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

                            return Ok(JsonConvert.SerializeObject(answer));
                        }

                        return Ok(_errorHelper.GetErrorRequest((int)ErrorEnums.UNKNOWN_ERROR));
                    }
                    
                    return Ok(_errorHelper.GetErrorRequest((int)ErrorEnums.UNKNOWN_ERROR));
                }

                _logger.LogError($"Такого пользователя не существует: {model.Login}");
                return Ok(_errorHelper.GetErrorRequest((int)ErrorEnums.UNKNOWN_ERROR));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Ok(_errorHelper.GetErrorRequest((int)ErrorEnums.UNKNOWN_ERROR));
            }
        }
    }
}