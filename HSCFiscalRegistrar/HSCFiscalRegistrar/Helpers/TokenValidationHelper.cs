using System;
using Microsoft.AspNetCore.Identity;
using Models;
using Models.Enums;

namespace HSCFiscalRegistrar.Helpers
{
    public class TokenValidationHelper
    {
        
        public ErrorEnums TokenValidator(UserManager<User> context, string token)
        {
            try
            {
                var user = context.FindByIdAsync(ParseId(token));
                
                if (user != null)
                {
                    if (user.Result.UserToken == token)
                    {
                        return DateTime.Now > user.Result.ExpiryDate ? ErrorEnums.SESSION_ERROR : ErrorEnums.GOOD_RES;
                    }
                    return ErrorEnums.UNAUTHORIZED_ERROR;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return ErrorEnums.UNKNOWN_ERROR;
        }

        public string ParseId(string token)
        {
            var tokenArray = token.Split('%');
            return tokenArray[0];
        }
    }
}