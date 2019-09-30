using System;
using HSCFiscalRegistrar.Enums;
using HSCFiscalRegistrar.Models;

namespace HSCFiscalRegistrar.Helpers
{
    public class TokenValidationHelper
    {
        public static int TokenValidator(ApplicationContext context, string token)
        {
            User user = context.Users.Find(ParseId(token));

            if (user != null)
            {
                if (user.UserToken == token)
                {
                    if (DateTime.Now < user.ExpiryDate )
                    {
                        return TokenError.GOOD_USER.GetHashCode();
                    }
                    else
                    {
                        return TokenError.TIME_EXCEPTIONS.GetHashCode();
                    }
                }
                else
                {
                    return TokenError.INVALID_TOKEN.GetHashCode();
                }
            }
            else
            {
                return TokenError.INVALID_USER.GetHashCode();
            }

            return TokenError.ANOTHER_ERROR.GetHashCode();
        }

        private static string ParseId(string token)
        {
            string[] tokenArray = token.Split('%');
            return tokenArray[0];
        }
    }
}