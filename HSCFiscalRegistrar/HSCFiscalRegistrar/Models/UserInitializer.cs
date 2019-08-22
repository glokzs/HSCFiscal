using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HSCFiscalRegistrar.Models
{
    public class UserInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminLogin = "Admin";
            string password = "Admin";

            Guid userToken = Guid.NewGuid();
            int deviceId = 12345;

            DateTime dateTime = DateTime.Now;

            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }

            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }

            if (await userManager.FindByNameAsync(adminLogin) == null)
            {
                User admin = new User
                {
                    UserName = adminLogin, UserToken = userToken, DeviceId = deviceId, PasswordHash = password,
                    DateTime = dateTime
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