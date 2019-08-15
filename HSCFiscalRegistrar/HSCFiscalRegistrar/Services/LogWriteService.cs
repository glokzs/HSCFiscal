using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NLog;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.Services
{
    public class LogWriteService
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static void LogWriter(dynamic obj)
        {
            var result = JsonConvert.SerializeObject(obj);
            logger.Debug(result);
        }    
    }
}
