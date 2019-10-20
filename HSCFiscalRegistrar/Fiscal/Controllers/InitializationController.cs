using System;
using System.Linq;
using System.Threading.Tasks;
using Fiscal.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using Fiscal.Data;
using Models.DTO.InitializeCashDesk.WebRequest;


namespace Fiscal.Controllers
{
    public class InitializationController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly Data.AppContext _context;

        public InitializationController(UserManager<User> userManager, Data.AppContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult AllCashDesk()
        {
            var res = _context.Kkms.ToList();
            return View(res);
        }


        [HttpGet]
        public IActionResult RegisterCashDesk()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ActivateKkm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterCashDesk(RegisterCashDeskViewModel model)
        {
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
                    
                };
                _context.Kkms.Add(kkm);
            }

            _context.SaveChanges();


            return RedirectToAction("AllCashDesk");
        }

        public IActionResult CheckName(RegisterCashDeskViewModel model)
        {
            var kkm = new Kkm
            {
                Name = model.Name,
                Description = model.Description,
            };

            if (_context.Kkms.Any(u => string.Equals(u.Name.Trim(), model.Name) && u.Id == kkm.Id))
            {
                return Ok(true);
            }
            else if (_context.Kkms.Any(u => string.Equals(u.Name.Trim(), model.Name)))
            {
                return Ok(false);
            }

            return Ok(true);
            
        }

        [HttpPost]
        public IActionResult Post([FromBody] WebRequest model)
        {
            Request requestOfd = new Request
            {
                Command = 5,
                Token = model.TokenOfd,
                ReqNum = 1,
                Service = new Service(new RegInfo())
            };


            return Ok(JsonConvert.SerializeObject(requestOfd));
        }
    }
}