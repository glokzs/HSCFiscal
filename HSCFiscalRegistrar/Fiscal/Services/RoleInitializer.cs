using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Models;
using Models.Enums;

namespace Fiscal.Serves
{
    public class RoleInitializer
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
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                User admin = new User() { Email = adminEmail, 
                    UserName = adminEmail, 
                    UserType = UserTypeEnum.TYPE_ADMIN};
                
                IdentityResult result = await userManager.CreateAsync(admin, password);
                
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}