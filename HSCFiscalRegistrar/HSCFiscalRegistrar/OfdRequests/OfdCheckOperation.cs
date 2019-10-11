using System;
using HSCFiscalRegistrar.DTO.Fiscalization.KKM;
using HSCFiscalRegistrar.DTO.Fiscalization.OFD;
using HSCFiscalRegistrar.Models.Operation;
using HSCFiscalRegistrar.Services;
using Microsoft.Extensions.Logging;

namespace HSCFiscalRegistrar.OfdRequests
{
    public class OfdCheckOperation
    {
        private readonly ILoggerFactory _loggerFactory;

        public OfdCheckOperation(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public async void OfdRequest(Operation operation, CheckOperationRequest checkOperationRequest)
        {
            var logger = _loggerFactory.CreateLogger("OfdCheckOperationRequest|Post");
            var fiscalOfdRequest = new FiscalOfdRequest(operation, checkOperationRequest);
            try
            {
                logger.LogInformation("Отправка запроса фискализации в ОФД");
                await HttpService.Post(fiscalOfdRequest);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }
        }
    }
}