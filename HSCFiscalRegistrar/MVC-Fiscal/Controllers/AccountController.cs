using Microsoft.AspNetCore.Mvc;

namespace MVC_Fiscal.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}