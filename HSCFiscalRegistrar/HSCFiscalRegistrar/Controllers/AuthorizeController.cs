using System.Linq;
using System.Threading.Tasks;
using HSCFiscalRegistrar.DTO.Data;
using HSCFiscalRegistrar.DTO.Errors;
using HSCFiscalRegistrar.DTO.Registration;
using HSCFiscalRegistrar.DTO.UserModel;
using HSCFiscalRegistrar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<JsonResult> Post([FromBody] UserChangePassword model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Login,
                model.Password,
                false,
                false);
            if (result.Succeeded)
            {
                switch (model.Command)
                {
                    case 1:
                        return Json(await SwitchPassword(model));
                    default:
                        return Json(await Login(model));
                }
            }
            else
            {
                return Json(ErrorsAuth.LoginError());
            }

        }

        private async Task<JsonResult> SwitchPassword([FromBody] UserChangePassword model)
        {

            var userLog = _userManager.Users.FirstOrDefault(r => r.UserName == model.Login);
            if (userLog != null && userLog.UserToken == model.Token)
            {
                userLog.DateTimeCreationToken = GenerateUserToken.TimeCreation();
                userLog.UserToken = GenerateUserToken.getGuidKey();
                if (model.Password == model.NewPassword)
                {
                    return Json(ErrorsAuth.PasswordAlready());
                }
                await _userManager.ChangePasswordAsync(userLog, model.Password, model.NewPassword);

                var response = await _userManager.UpdateAsync(userLog);

                if (response.Succeeded)
                {
                    ResponseServerReg answer = new ResponseServerReg
                    {
                        Successful = "Password changed successfully",
                        Token = userLog.UserToken
                    };

                    return Json(answer);
                }
                else
                {
                    return Json("Errors system");
                }
            }
            else
            {

                return Json(ErrorsAuth.UserNotFound());
            }
        }

        private async Task<JsonResult> Login([FromBody] UserDTO model)
        {
            var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Login);

            appUser.DateTimeCreationToken = GenerateUserToken.TimeCreation();
            appUser.UserToken = GenerateUserToken.getGuidKey();

            var response = await _userManager.UpdateAsync(appUser);

            if (response.Succeeded)
            {
                var dto = new AnswerServerAuth
                {
                    Data = new Data
                    {
                        Token = appUser.UserToken
                    }
                };

                return Json(dto);
            }
            else
            {
                return Json("Ошибка в системе!");
            }
        }
    }
}