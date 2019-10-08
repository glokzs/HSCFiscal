using System.Threading.Tasks;
using HSCFiscalRegistrar.Models;
using Microsoft.AspNetCore.Identity;

namespace HSCFiscalRegistrar.Helpers
{
    public class UserInitializer
    {
        public static async Task InitializeAsync(RoleManager<IdentityRole> roleManager)
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
        }
    }
}