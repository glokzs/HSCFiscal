using System.Linq;
using System.Threading.Tasks;
using HSCFiscalRegistrar.DTO.Errors;
using HSCFiscalRegistrar.DTO.Registration;
using HSCFiscalRegistrar.DTO.UserModel;
using HSCFiscalRegistrar.Helpers;
using HSCFiscalRegistrar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangePasswordController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public ChangePasswordController(UserManager<User> userManager,
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
                User user = _userManager.Users.FirstOrDefault(r => r.UserName == model.Login);

                if (user != null && user.UserToken.ToString() == model.Token)
                {
                    user.DateTimeCreationToken = GenerateUserToken.TimeCreation();
                    user.UserToken = GenerateUserToken.getGuidKey();

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

            return Json(ErrorsAuth.LoginError());
        }
    }
}