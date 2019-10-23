using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiscal.Data;
using Fiscal.ViewModels;
using HSCFiscalRegistrar.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DTO;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Models.DTO.InitializeCashDesk.RequestOfd;
using Models.DTO.InitializeCashDesk.ResponseOfd;
using Models.DTO.RequestOfd;
using Models.Services;


namespace Fiscal.Controllers
{
    [Authorize]
    public class InitializeCashDeskController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly AppDataFiscalContext _context;

        public InitializeCashDeskController(UserManager<User> userManager, AppDataFiscalContext context)
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

        [HttpGet]
        public IActionResult ChangeToken()
        {
            if (User.IsInRole("blocked") || User.IsInRole("operator"))
            {
                return RedirectToAction("BlockPage", "BlockedUser");
            }

            return View();
        }

        [HttpPost]
        public IActionResult ChangeToken(Kkm kkmChange)
        {
            if (User.IsInRole("blocked") || User.IsInRole("operator"))
            {
                return RedirectToAction("BlockPage", "BlockedUser");
            }

            try
            {
                if (ModelState.IsValid)
                {
                    var kkm = _context.Kkms.FirstOrDefault(i => i.Id == kkmChange.Id);

                    if (kkm != null)
                    {
                        RequestOfdCashDesk kkmRequest = new RequestOfdCashDesk
                        {
                            FnsKkmId = kkm.FnsKkmId,
                            DeviceId = kkm.DeviceId,
                            TokenOfd = kkmChange.OfdToken,
                            SerialNumber = kkm.SerialNumber,
                            Iin = kkm.Iin,
                            NameOrg = kkm.NameOrg,
                            ReqNum = 56
                        };

                        var response = RequestOfd(kkmRequest);

                        if (response.Result.Result.ResultCode == 0)
                        {
                            ResponseWeb(response, kkm.Id);
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Некорректный запрос, попробуйте снова");
                            return View(new Kkm() { Id = kkmChange.Id });
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Некорректный запрос, попробуйте снова");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Некорректный запрос, попробуйте снова");
            }

            

            return RedirectToAction("GetCashDesk", "InitializeCashDesk", new {id = kkmChange.UserId});
        }

        [HttpPost]
        [Authorize(Roles = "user")]
        public IActionResult ActivateKkm(Kkm kkmActivate)
        {
            if (User.IsInRole("blocked") || User.IsInRole("operator"))
            {
                return RedirectToAction("BlockPage", "BlockedUser");
            }


            try
            {
                if (ModelState.IsValid)
                {
                    var kkm = _context.Kkms.FirstOrDefault(i => i.Id == kkmActivate.Id);

                    if (kkm != null)
                    {
                        RequestOfdCashDesk kkmRequest = new RequestOfdCashDesk
                        {
                            FnsKkmId = kkmActivate.FnsKkmId,
                            DeviceId = kkmActivate.DeviceId,
                            TokenOfd = kkmActivate.OfdToken,
                            SerialNumber = kkm.SerialNumber,
                            Iin = kkm.Iin,
                            NameOrg = kkm.NameOrg,
                            ReqNum = kkm.ReqNum
                        };

                        var response = RequestOfd(kkmRequest);

                        if (response.Result.Result.ResultCode == 0)
                        {
                            ResponseWeb(response, kkm.Id);
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Некорректный запрос, попробуйте снова");
                        }
                    }

                    
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Некорректный запрос, попробуйте снова");

                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Некорректный запрос, попробуйте снова");
            }
            

            return RedirectToAction("GetCashDesk", "InitializeCashDesk", new {id = kkmActivate.UserId});
        }

        private Task<ResponseOfdCheckDesk> RequestOfd(RequestOfdCashDesk kkmRequest)
        {
            var kkm = new OfdKkm
            {
                SerialNumber = kkmRequest.SerialNumber,
                PointOfPaymentNumber = "1",
                FnsKkmId = kkmRequest.FnsKkmId,
                TerminalNumber = "1"
            };

            var org = new global::Models.DTO.RequestOperatorOfd.Org
            {
                Inn = kkmRequest.Iin,
                Okved = "",
                TaxationType = 0,
                Title = kkmRequest.NameOrg
            };

            Request requestOfd = new Request
            {
                Command = 5,
                DeviceId = kkmRequest.DeviceId,
                ReqNum = kkmRequest.ReqNum++,
                Token = kkmRequest.TokenOfd,
                Service = new Service(new RegInfo(org, kkm))
            };

            Task<ResponseOfdCheckDesk> res = GetResponse(requestOfd);

            return res;
        }

        private void ResponseWeb(Task<ResponseOfdCheckDesk> res, string kkmId)
        {
            string kkmIdOfd = res.Result.ServiceOfdDesk.RegInfoOfdDesk.Kkm.KkmIdOfd;

            int intKkmId = int.Parse(kkmIdOfd);

            var resKkm = _context.Kkms.FirstOrDefault(d => d.Id == kkmId);

            if (resKkm != null)
            {
                resKkm.DeviceId = intKkmId;
                resKkm.NameOrg = res.Result.ServiceOfdDesk.RegInfoOfdDesk.Pos.Title;
                resKkm.Address = res.Result.ServiceOfdDesk.RegInfoOfdDesk.Pos.Address;
                resKkm.OfdToken = res.Result.TokenOfd;
                resKkm.CurrentStatus = "Готова к работе";
                resKkm.SerialNumber = res.Result.ServiceOfdDesk.RegInfoOfdDesk.Kkm.SerialNumber;
                resKkm.FnsKkmId = res.Result.ServiceOfdDesk.RegInfoOfdDesk.Kkm.FnsKkmId;
                resKkm.ReqNum += 1;
                resKkm.PointOfPayment = "";
                resKkm.TerminalNumber = "";

                _context.Kkms.Update(resKkm);
                _context.SaveChanges();

                var resUser = _userManager.Users.FirstOrDefault(i => i.Id == resKkm.UserId);

                if (resUser != null)
                {
                    resUser.Title = resKkm.NameOrg;
                }
            }
        }

        private async Task<ResponseOfdCheckDesk> GetResponse(Request requestOfd)
        {
            var x = await HttpService.Post(requestOfd);
            string json = JsonConvert.SerializeObject(x);
            var response = JsonConvert.DeserializeObject<ResponseOfdCheckDesk>(json);

            return response;
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

            var org = new global::Models.DTO.RequestOperatorOfd.Org();

            return Ok(true);
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