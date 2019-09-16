using System;

namespace HSCFiscalRegistrar.Helpers
{
    public static class GenerateUserToken
    {
        private static Guid _guid;

        public static Guid getGuidKey()
        {
            return _guid = Guid.NewGuid();
        }

        public static DateTime TimeCreation()
        {
            return DateTime.Now;
        }
    }
}