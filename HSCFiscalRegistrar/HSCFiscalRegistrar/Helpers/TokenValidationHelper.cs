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
        private static UserManager<User> _userManager;
        public TokenValidationHelper(ApplicationContext context, UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public static async Task<bool> TokenValidator(ClaimsPrincipal user, string token)
        {
            User tokenOwner = await _userManager.GetUserAsync(user);
            return tokenOwner.UserToken.ToString() == token;
        }
    }
}