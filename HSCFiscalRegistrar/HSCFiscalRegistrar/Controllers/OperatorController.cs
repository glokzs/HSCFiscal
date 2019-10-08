using System;
using System.Threading.Tasks;
using HSCFiscalRegistrar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HSCFiscalRegistrar.Controllers
{
    public class OperatorController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private ApplicationContext _context;
        
        [HttpPost]
        public async Task<IActionResult> CreateOperator()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = new User
                    {
                        UserName = "admin@admin.com",
                        PasswordHash = "_Aa123456"
                    };
                    var result = await _userManager.CreateAsync(user, user.PasswordHash);

                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, false);
                        return Ok();
                    }
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