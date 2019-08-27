using System.Collections.Generic;
using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.Errors
{
    public class ErrorsAuth
    {
        private OutputErrorsEnum Code { get; set; }
        private string Text { get; set; }

        public static DataErrors loginError()
        {
            return new DataErrors
            {
                Errors = new[]
                {
                    new Error
                    {
                        Code = 1,
                        Text = "Vlalads"
                    },
                }
            };
        }

        public static DataErrors invalidToken()
        {
            return new DataErrors
            {
                Errors = new[]
                {
                    new Error
                    {
                        Code = 9,
                        Text = "Token error"
                    }
                },
            };
        }
    }
}