using System;

namespace HSCFiscalRegistrar.Exceptions
{
    public class DbUpdateException : Exception
    {
        public DbUpdateException(string message)
            : base(message: message)
        {
        }
    }
}