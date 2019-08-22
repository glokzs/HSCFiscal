using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HSCFiscalRegistrar.DTO.Errors;
using HSCFiscalRegistrar.DTO.UserModel;
using HSCFiscalRegistrar.Enums;
using HSCFiscalRegistrar.Models;
using HSCFiscalRegistrar.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDBbContext _context;

        public AuthorizeController(UserManager<User> userManager, SignInManager<User> signInManager,
            ApplicationDBbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpPost]
        public async Task<JsonResult> Post([FromBody] Data model)
        {

            var result =
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
                    DateTime = DateTime.Now,
                    UserToken = userToken.Token,
                    DeviceId = model.DeviceId

                };

            return Json(userToken);

            }
            else
            {
                Errors errors = new Errors
                {
                    Text = "Invalid login",
                    Code = OutputErrorsEnum.InvalidLoginOrPassword
               };
                return Json(errors);
            }
        }
    }
}
    