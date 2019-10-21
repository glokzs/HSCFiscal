using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fiscal.Models;
using Microsoft.AspNetCore.Authorization;

namespace Fiscal.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.IsInRole("blocked"))
            {
                return RedirectToAction("BlockPage", "BlockedUser");
            }
            
            return View();
        }

        public IActionResult Privacy()
        {
            if (User.IsInRole("blocked"))
            {
                return RedirectToAction("BlockPage", "BlockedUser");
            }
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            if (User.IsInRole("blocked"))
            {
                return RedirectToAction("BlockPage", "BlockedUser");
            }
            
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}