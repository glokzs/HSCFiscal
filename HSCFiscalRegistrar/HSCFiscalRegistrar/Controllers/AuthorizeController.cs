using System.Linq;
using System.Threading.Tasks;
using HSCFiscalRegistrar.DTO.Data;
using HSCFiscalRegistrar.DTO.Errors;
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
        public async Task<JsonResult> Post([FromBody] UserDTO model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Login,
                model.Password,
                false,
                false);
            if (result.Succeeded)
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
                            Token = appUser.UserToken.ToString()
                        }
                    };

                    return Json(dto);
                }
                else
                {
                    return Json("Ошибка в системе!");
                }
            }
            else
            {
                return Json(ErrorsAuth.LoginError());
            }

        }
    }
}