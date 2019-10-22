using System;
using System.Linq;
using System.Threading.Tasks;
using Fiscal.Data;
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
        private readonly AppDataFiscalContext _context;

        public OperatorController(
            UserManager<User> userManager,
            AppDataFiscalContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add(string id)
        {
            if (User.IsInRole("blocked") || User.IsInRole("operator"))
            {
                return RedirectToAction("BlockPage", "BlockedUser");
            }

            ViewBag.Kkms = _context.Kkms.Where(p => p.UserId == id);
                
            return View(new RegisterOperatorViewModel() {OwnerId = id});
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(RegisterOperatorViewModel model)
        {
            if (User.IsInRole("blocked") || User.IsInRole("operator"))
            {
                return RedirectToAction("BlockPage", "BlockedUser");
            }

            if (!ModelState.IsValid) return View();
            
            var user = new User
            {
                UserName = model.Email,
                Email = model.Email,
                OperatorCode = _userManager.Users.Count() + 1,
                Fio = model.Name,
                UserType = UserTypeEnum.TYPE_OPERATOR,
                OwnerId = model.OwnerId,
                KkmId = model.KKMId
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "operator");
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