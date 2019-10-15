using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace HSCFiscalRegistrar.Controllers
{
    [Route("api/[controller]")]
    public class OperatorController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationContext _context;

        public OperatorController( UserManager<User> userManager, ApplicationContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpPost]
        
        public async Task<IActionResult> Post()
        {
            
            try
            {
                string adminEmail = "admin@gmail.com";
                string password = "_Aa123456";
                
                if (await _userManager.FindByNameAsync(adminEmail) == null)
                {
                    User admin = new User {
                        Email = adminEmail,
                        UserName = adminEmail,
                        PasswordHash = password
                    };

                    IdentityResult result = await _userManager.CreateAsync(admin, password);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(admin, "admin");
                    }
                    Operator operatorModel = new Operator
                    {
                        UserId = admin.Id,
                        Name = "Ibragim",
                        Code = 228,
                        KkmId = "2",
                        OrgId = "3"
                        
                    };
                    _context.Operators.Add(operatorModel);
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