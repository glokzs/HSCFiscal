using System;
using HSCFiscalRegistrar.DTO.CloseShift;
using HSCFiscalRegistrar.Models.APKInfo;
using HSCFiscalRegistrar.Services;
using Microsoft.Extensions.Logging;

namespace HSCFiscalRegistrar.OfdRequests
{
    public class OfdShiftClose
    {
        private readonly ILoggerFactory _loggerFactory;

        public OfdShiftClose(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public async void Request(Kkm kkm, Org org, int shiftNumber)
        {
            var logger = _loggerFactory.CreateLogger("OfdCloseShiftRequest|Post");
            var closeShiftRequest = new CloseShiftRequest(kkm, org, shiftNumber);
            try
            {
                logger.LogInformation("Отправка запроса на закрытие смены в ОФД");
                await HttpService.Post(closeShiftRequest);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }
            
        }
    }
}