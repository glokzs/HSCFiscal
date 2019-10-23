using System;

namespace HSCFiscalRegistrar.Exceptions
{
    public class AuthorizeException : Exception
    {
        public AuthorizeException(string message)
            : base(message: message)
        {
        }
    }
}