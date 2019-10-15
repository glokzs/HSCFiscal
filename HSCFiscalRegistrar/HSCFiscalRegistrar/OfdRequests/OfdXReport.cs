using System;
using HSCFiscalRegistrar.DTO.XReport.OfdRequest;
using HSCFiscalRegistrar.Services;
using Microsoft.Extensions.Logging;
using Models.APKInfo;

namespace HSCFiscalRegistrar.OfdRequests
{
    public class OfdXReport
    {
        private readonly ILoggerFactory _loggerFactory;

        public OfdXReport(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public async void Request(Kkm kkm, Org org)
        {
            var logger = _loggerFactory.CreateLogger("OfdXReport|Post");
            var request = new XReportOfdRequestModel(kkm, org);
            try
            {
                logger.LogInformation("Отправка запроса на Х-Отчет в ОФД");
                await HttpService.Post(request);
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
            }
            
        }
    }
}