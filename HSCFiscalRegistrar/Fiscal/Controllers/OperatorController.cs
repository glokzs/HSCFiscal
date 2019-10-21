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
        public IActionResult Add(string id)
        {
            if (User.IsInRole("blocked") || User.IsInRole("operator"))
            {
                return RedirectToAction("BlockPage", "BlockedUser");
            }
            
            return View(new RegisterOperatorViewModel(){OwnerId = id});
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

            var owner = _userManager.Users.FirstOrDefault(u => u.Id == model.OwnerId);

            var user = new User
            {
                UserName = model.Email,
                Email = model.Email,
                OperatorCode = _userManager.Users.Count() + 1,
                Fio = model.Name,
                UserType = UserTypeEnum.TYPE_OPERATOR,
                OwnerId = model.OwnerId,
                Title = owner.Title
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