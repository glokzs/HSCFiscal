using NLog;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.Services
{
    public class LogWriteService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void LogWrite(dynamic obj)
        {
            var result = JsonConvert.SerializeObject(obj);
            logger.Debug(result);
        }
    }
}