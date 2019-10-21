using System.Collections.Generic;
using System.Linq;
using Fiscal.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Models.DTO.InitializeCashDesk.WebRequest;


namespace Fiscal.Controllers
{
    [Authorize]
    public class InitializeCashDeskController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly Data.AppContext _context;

        public InitializeCashDeskController(UserManager<User> userManager, Data.AppContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult AllCashDesk()
        {
            if (User.IsInRole("blocked") || User.IsInRole("operator"))
            {
                return RedirectToAction("BlockPage", "BlockedUser");
            }
            
            var res = _context.Kkms.ToList();
            return View(res);
        }


        [HttpGet]
        public IActionResult RegisterCashDesk()
        {
            if (User.IsInRole("blocked") || User.IsInRole("operator"))
            {
                return RedirectToAction("BlockPage", "BlockedUser");
            }
            
            return View();
        }

        [HttpGet]
        public IActionResult ActivateKkm()
        {
            if (User.IsInRole("blocked") || User.IsInRole("operator"))
            {
                return RedirectToAction("BlockPage", "BlockedUser");
            }
            
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "user")]
        public IActionResult RegisterCashDesk(RegisterCashDeskViewModel model)
        {
            if (User.IsInRole("blocked") || User.IsInRole("operator"))
            {
                return RedirectToAction("BlockPage", "BlockedUser");
            }
            
            var pattern = "SWK";
            var number = 10000000 + _context.Kkms.Count() + 1;
            string res = number.ToString().Substring(1);
            string serialNumber = pattern + res;

            var user = _userManager.Users.FirstOrDefault(i => i.Id == model.UserId);

            if (user != null)
            {
                Kkm kkm = new Kkm
                {
                    Name = model.Name,
                    Description = model.Description,
                    SerialNumber = serialNumber,
                    UserId = user.Id,
                    CurrentStatus = "Создана",
                    Address = user.Address,
                    Mode = "Режим отправки в ОФД",
                    NameOrg = user.Title,
                    Iin = user.Inn
                };
                _context.Kkms.Add(kkm);
            }

            _context.SaveChanges();
            
            return RedirectToAction("GetCashDesk", "InitializeCashDesk", new {id = model.UserId});
        }

        public IActionResult CheckName(RegisterCashDeskViewModel model)
        {
            if (User.IsInRole("blocked") || User.IsInRole("operator"))
            {
                return RedirectToAction("BlockPage", "BlockedUser");
            }

            List<Kkm> reskkm = _context.Kkms.Where(u => u.UserId == model.UserId).ToList();

            var res = reskkm.FirstOrDefault(i => i.Name == model.Name);

            if (res != null)
            {
                return Ok(false);
            }

            return Ok(true);

        }

        [HttpPost]
        public IActionResult Post([FromBody] WebRequest model)
        {
            if (User.IsInRole("blocked") || User.IsInRole("operator"))
            {
                return RedirectToAction("BlockPage", "BlockedUser");
            }
            
            Request requestOfd = new Request
            {
                Command = 5,
                Token = model.TokenOfd,
                ReqNum = 1,
                Service = new Service(new RegInfo())
            };


            return Ok(JsonConvert.SerializeObject(requestOfd));
        }

        public IActionResult GetCashDesk(string id)
        {
            if (User.IsInRole("blocked") || User.IsInRole("operator"))
            {
                return RedirectToAction("BlockPage", "BlockedUser");
            }
            return View(_context.Kkms.Where(p => p.UserId == id).ToList());
        }
    }
}