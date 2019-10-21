using Microsoft.AspNetCore.Mvc;

namespace Fiscal.Controllers
{
    public class BlockedUserController : Controller
    {
        public IActionResult BlockPage()
        {
            return View();
        }
    }
}