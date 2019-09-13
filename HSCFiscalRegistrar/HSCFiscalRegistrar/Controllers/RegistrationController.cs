using System.Threading.Tasks;
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
    public class RegistrationController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public RegistrationController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<JsonResult> Post([FromBody] UserRegistration model)
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

                    return Json(ErrorsAuth.CheckLogin());
                }
                else
                {
                    return Json(ErrorsAuth.RegisterError());
                }
            }

            var str = "Invalid Error";
            return Json(str);
        }
    }
}