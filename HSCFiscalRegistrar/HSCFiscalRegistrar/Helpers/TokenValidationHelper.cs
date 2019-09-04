using System.Linq;
using HSCFiscalRegistrar.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HSCFiscalRegistrar.Helpers
{
    public class TokenValidationHelper 
    {
       public static async Task<bool> TokenValidator(
           ClaimsPrincipal user, 
            UserManager<User> userManager, 
            string token)
        {
            User tokenOwner = await userManager.GetUserAsync(user);
            return tokenOwner.UserToken.ToString() == token;
        }
    }
}