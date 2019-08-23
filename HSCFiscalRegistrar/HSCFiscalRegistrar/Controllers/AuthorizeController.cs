using System;
using System.Threading.Tasks;
using HSCFiscalRegistrar.DTO.Errors;
using HSCFiscalRegistrar.DTO.UserModel;
using HSCFiscalRegistrar.Enums;
using HSCFiscalRegistrar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationContext _context;

        public AuthorizeController(UserManager<User> userManager, SignInManager<User> signInManager,
            ApplicationContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpPost]
        public async Task<JsonResult> Post([FromBody] Data model)
        {

            SignInResult result =
                await _signInManager.PasswordSignInAsync(model.Login, model.Password, false, false);

            if (result.Succeeded)
            {
                UserToken userToken = new UserToken
            {
                Token = Guid.NewGuid()
            };

                User user = new User
                {
                    UserName = model.Login,
                    PasswordHash = model.Password,
                    DeviceId = model.DeviceId

                };

                user = await _userManager.FindByNameAsync(model.Login);

                user.DateTime = DateTime.Now;
                user.UserToken = userToken.Token;

                var buf = _userManager.UpdateAsync(user);

                return Json(userToken);

            }
            Errors errors = new Errors
                {
                    Text = "Invalid login",
                    Code = OutputErrorsEnum.InvalidLoginOrPassword
               };
                return Json(errors);
        }
    }
}
    