using System.Threading.Tasks;
using HSCFiscalRegistrar.Models;
using Microsoft.AspNetCore.Identity;

namespace HSCFiscalRegistrar.Helpers
{
    public class UserInitializer
    {

        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminEmail = "admin@gmail.com";
            string password = "_Aa123456";

            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }

            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }

            if (await roleManager.FindByIdAsync("1") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("1"));
            }

            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User
                {
                    Email = adminEmail, 
                    UserName = adminEmail, 
                    PasswordHash = password,
                };

                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}