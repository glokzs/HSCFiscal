using System.Linq;
using System.Threading.Tasks;
using Fiscal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Enums;

namespace Fiscal.Controllers
{
    public class OperatorController : Controller
    {
        private readonly UserManager<User> _userManager;

        public OperatorController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add() => View();
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(RegisterOperatorViewModel model)
        {
            if (!ModelState.IsValid) return View();
            var user = new User
            {
                UserName = model.Email,
                Email = model.Email,
                OperatorCode = _userManager.Users.Count() + 1,
                Fio = model.Name,
                UserType = UserTypeEnum.TYPE_OPERATOR,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("index", "Home");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View();
        }
        
    }
}