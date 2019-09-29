using System;
using System.Text.RegularExpressions;

namespace HSCFiscalRegistrar.Helpers
{
    public static class GenerateUserToken
    {
        private const int Hours = 24;
        public static string GetGuidKey()
        {
            return Regex.Replace(Convert.ToBase64String(Guid.NewGuid().ToByteArray()), "[/+=]", "");
        }

        public static DateTime TimeCreation()
        {
            return DateTime.Now;
        }

        public static DateTime ExpiryDate()
        {
            TimeSpan time = new TimeSpan(0, Hours, 0, 0);
            DateTime combined = DateTime.Now.Add(time);
            return combined;
        }

        public static string Token(string appUserId)
        {
            return $"{appUserId}%{GetGuidKey()}";
        }
    }
}