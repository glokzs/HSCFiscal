﻿using System.Diagnostics;
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
            if (User.IsInRole("blocked") || User.IsInRole("operator"))
            {
                return RedirectToAction("BlockPage", "BlockedUser");
            }

            return View();
        }

        public IActionResult Privacy()
        {
            if (User.IsInRole("blocked") || User.IsInRole("operator"))
            {
                return RedirectToAction("BlockPage", "BlockedUser");
            }
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            if (User.IsInRole("blocked") || User.IsInRole("operator"))
            {
                return RedirectToAction("BlockPage", "BlockedUser");
            }
            
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}