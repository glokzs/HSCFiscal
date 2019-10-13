using System;
using System.Data;
using System.Security.Authentication;
using Castle.Core.Logging;
using HSCFiscalRegistrar.Models;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace HSCFiscalRegistrar.Helpers
{
    public class TokenValidationHelper
    {
        public string TokenValidator(ApplicationContext context, string token)
        {
            try
            {
                User user = context.Users.Find(ParseId(token));
                
                if (user != null)
                {
                    if (user.UserToken == token)
                    {
                        if (DateTime.Now > user.ExpiryDate)
                        {
                            
                        }
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return null;
        }

        public string ParseId(string token)
        {
            string[] tokenArray = token.Split('%');
            return tokenArray[0];
        }
    }
}