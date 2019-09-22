using System.Collections.Generic;
using System.Linq;
using HSCFiscalRegistrar.Models;
using Microsoft.AspNetCore.Identity;

namespace HSCFiscalRegistrar.Helpers
{
    public class TokenValidationHelper
    {
        public static bool TokenValidator(ApplicationContext context, string token)
        {
            User user = context.Users.Find(ParseId(token));
            return user.UserToken == token;
        }

        private static string ParseId(string token)
        {
            string[] tokenArray = token.Split('%');
            return tokenArray[0];
        }
    }
}