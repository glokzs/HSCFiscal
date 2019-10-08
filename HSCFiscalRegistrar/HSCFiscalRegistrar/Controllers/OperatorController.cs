using System;
using System.Threading.Tasks;
using HSCFiscalRegistrar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    public class OperatorController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private ApplicationContext _context;

        public OperatorController(SignInManager<User> signInManager, UserManager<User> userManager, ApplicationContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }

        [HttpPost]
        
        public async Task<IActionResult> Post()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = new User
                    {
                        UserName = "admin@admin.com",
                        PasswordHash = "_Aa123456",
                        Id = "3"
                        
                    };
                    
                    var result = await _userManager.CreateAsync(user, user.PasswordHash);

                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, false);
                    }
                    
                    Operator modelOperator = new Operator
                        
                    {
                        UserId = user.Id,
                        Name = "Ibragim",
                        Code = 228,
                        KkmId = "2",
                        OrgId = "3"
                    };

                    _context.Operators.Add(modelOperator);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return Ok();
        }
    }
}