using System;

namespace HSCFiscalRegistrar.Exceptions
{
    public class UserNullException : Exception
    {
        public UserNullException(string message)
            : base(message: message)
        {
        }
    }
}