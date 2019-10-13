using System;
using System.Data;
using System.Security.Authentication;
using Castle.Core.Logging;
using HSCFiscalRegistrar.Enums;
using HSCFiscalRegistrar.Models;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace HSCFiscalRegistrar.Helpers
{
    public class TokenValidationHelper
    {
        public ErrorEnums TokenValidator(ApplicationContext context, string token)
        {
            try
            {
                User user = context.Users.Find(ParseId(token));
                
                if (user != null)
                {
                    if (user.UserToken == token)
                    {
                        return DateTime.Now > user.ExpiryDate ? ErrorEnums.SESSION_ERROR : ErrorEnums.GOOD_RES;
                    }
                    else
                    {
                        return ErrorEnums.UNAUTHORIZED_ERROR;
                    }
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
            string[] tokenArray = token.Split('%');
            return tokenArray[0];
        }
    }
}