using System;
namespace HSCFiscalRegistrar.Helpers
{
    public class GeneratorFiscalSign
    
    {
        public static int GenerateFiscalSign()
        {
            DateTime dateTimeNow = DateTime.Now;
            int dayHavePassed = dateTimeNow.DayOfYear - 1;
            string year = Convert.ToString(dateTimeNow.Year);
            string day = Convert.ToString(dayHavePassed);
            int seconds = dateTimeNow.Hour*60 + dateTimeNow.Minute*60 + dateTimeNow.Second;
            string convertSeconds = Convert.ToString(seconds);
            string convertDate = String.Concat(year + day + convertSeconds).Substring(2);
            return Convert.ToInt32(convertDate);
        }
    }
}