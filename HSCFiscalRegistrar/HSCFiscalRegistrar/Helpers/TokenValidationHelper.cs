using System;
using System.Data;
using System.Security.Authentication;
using HSCFiscalRegistrar.Models;

namespace HSCFiscalRegistrar.Helpers
{
    public class TokenValidationHelper
    {
        public Exception TokenValidator(ApplicationContext context, string token)
        {
            User user = context.Users.Find(ParseId(token));
            if (user != null)
            {
                if (user.UserToken == token)
                {
                    if (DateTime.Now > user.ExpiryDate)
                    {
                        return new InvalidExpressionException();
                    }
                }
                else
                {
                    return new AuthenticationException();
                }
            }
            else
            {
                return new NullReferenceException();
            }

            return null;
        }

        private static string ParseId(string token)
        {
            string[] tokenArray = token.Split('%');
            return tokenArray[0];
        }
    }
}