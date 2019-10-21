using System.Linq;
using System.Threading.Tasks;
using Fiscal.Data;
using Fiscal.Interface;
using Fiscal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Enums;

namespace Fiscal.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly AppDataFiscalContext _dataFiscalContext;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
            IEmailSender emailSender, AppDataFiscalContext dataFiscalContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _dataFiscalContext = dataFiscalContext;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Register()
        {
            if (User.IsInRole("blocked"))
            {
                return RedirectToAction("BlockPage", "BlockedUser");
            }

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult RegisterMerch()
        {
            if (User.IsInRole("blocked"))
            {
                return RedirectToAction("BlockPage", "BlockedUser");
            }

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> RegisterMerch(RegisterMerchViewModel model)
        {
            if (User.IsInRole("blocked"))
            {
                return RedirectToAction("BlockPage", "BlockedUser");
            }

            if (!ModelState.IsValid) return View();
            User user = new User
            {
                Inn = model.IIN,
                Title = model.Title,
                Address = model.Adres,
                UserName = model.Email,
                TaxationType = model.TaxationType,
                VAT = model.VAT,
                VATNumber = model.VATNumber,
                VATSeria = model.VATSeria,
                Fio = model.FIO,
                PhoneNumber = model.PhoneNumberUser,
                Email = model.Email,
                UserType = UserTypeEnum.TYPE_MERCHANT
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "user");

                var email = model.Email;

                var subject = "Fiscal Team";

                var message =
                    $"<table><tr><td>Дорогой, {model.FIO}</td></tr><tr><td>ссылка для входа:<span>https://localhost:5001/account/login</span></td></tr><tr><td>Логин: {model.Email}</td></tr><tr><td>Пароль: {model.Password}</td></tr><tr><td>с уважением, ваша команда ~Fiscal~</td></tr></table>";

                await _emailSender.SendEmailAsync(email, subject, message);

                return RedirectToAction("index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (User.IsInRole("blocked"))
            {
                return RedirectToAction("BlockPage", "BlockedUser");
            }

            if (userId == null || code == null)
            {
                return View("Error");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return View("Error");
            }

            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
                return RedirectToAction("Index", "Home");
            return View("Error");
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            if (User.IsInRole("blocked"))
            {
                return RedirectToAction("BlockPage", "BlockedUser");
            }

            return View(new LoginViewModel {ReturnUrl = returnUrl});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ChangePassword(string id)
        {
            if (User.IsInRole("blocked"))
            {
                return RedirectToAction("BlockPage", "BlockedUser");
            }

            User user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            ChangePasswordViewModel model = new ChangePasswordViewModel {Id = user.Id, Email = user.Email};

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (User.IsInRole("blocked"))
            {
                return RedirectToAction("BlockPage", "BlockedUser");
            }

            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    var passwordValidator =
                        HttpContext.RequestServices.GetService(typeof(IPasswordValidator<User>)) as
                            IPasswordValidator<User>;
                    var passwordHasher =
                        HttpContext.RequestServices.GetService(typeof(IPasswordHasher<User>)) as IPasswordHasher<User>;

                    if (passwordValidator != null)
                    {
                        IdentityResult result =
                            await passwordValidator?.ValidateAsync(_userManager, user, model.NewPassword);
                        if (result.Succeeded)
                        {
                            user.PasswordHash = passwordHasher?.HashPassword(user, model.NewPassword);
                            await _userManager.UpdateAsync(user);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Пользователь не найден");
                }
            }

            return View(model);
        }

        public IActionResult CheckName(RegisterCashDeskViewModel model)
        {
            if (User.IsInRole("blocked"))
            {
                return RedirectToAction("BlockPage", "BlockedUser");
            }

            var kkm = new Kkm()
            {
                Name = model.Name,
                Description = model.Description,
            };

            if (_dataFiscalContext.Kkms.Any(u => string.Equals(u.Name.Trim(), model.Name) && u.Id == kkm.Id))
            {
                return Ok(true);
            }
            else if (_dataFiscalContext.Kkms.Any(u => string.Equals(u.Name.Trim(), model.Name)))
            {
                return Ok(false);
            }

            return Ok(true);
        }

        public IActionResult CheckEmail(RegisterMerchViewModel model)
        {
            if (_userManager.Users.Any(u => string.Equals(u.Email.Trim(), model.Email.Trim())))
            {
                return Ok(false);
            }

            return Ok(true);
        }

        public IActionResult CheckIin(RegisterMerchViewModel model)
        {
            if (_userManager.Users.Any(u => string.Equals(u.Inn.Trim(), model.IIN.Trim())))
            {
                return Ok(false);
            }

            return Ok(true);
        }

        public IActionResult CheckTitle(RegisterMerchViewModel model)
        {
            if (_userManager.Users.Any(u => string.Equals(u.Title.Trim(), model.Title.Trim())))
            {
                return Ok(false);
            }

            return Ok(true);
        }
    }
}