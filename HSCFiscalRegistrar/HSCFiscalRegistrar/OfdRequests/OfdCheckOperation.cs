using System;
using System.Net;
using System.Threading.Tasks;
using HSCFiscalRegistrar.DTO.Fiscalization.KKM;
using HSCFiscalRegistrar.DTO.Fiscalization.OFD;
using HSCFiscalRegistrar.DTO.Fiscalization.OFDResponse;
using HSCFiscalRegistrar.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using static HSCFiscalRegistrar.Services.HttpService;

namespace HSCFiscalRegistrar.OfdRequests
{
    public class OfdCheckOperation
    {
        private readonly ILoggerFactory _loggerFactory;

        public OfdCheckOperation(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public OfdFiscalResponse OfdRequest(Operation operation, CheckOperationRequest checkOperationRequest)
        {
            var logger = _loggerFactory.CreateLogger("OfdCheckOperationRequest|Post");
            var fiscalOfdRequest = new FiscalOfdRequest(operation, checkOperationRequest);
            try
            {
                logger.LogInformation("Отправка запроса фискализации в ОФД");
                var x = Post(fiscalOfdRequest);
                var json = JsonConvert.SerializeObject(x);
                var response = JsonConvert.DeserializeObject<OfdFiscalResponse>(json);
                return response;
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }

            return null;

        }
    }
}