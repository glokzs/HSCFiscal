using System;
using Models;
using Models.DTO.XReport.OfdRequest;
using Models.Services;
using Serilog;

namespace HSCFiscalRegistrar.OfdRequests
{
    public class OfdXReport
    {
        public async void Request(Kkm kkm, User user)
        {
            
            var request = new XReportOfdRequestModel(kkm, user);
            try
            {
                Log.Information("OfdXReport|Post");
                Log.Information("Отправка запроса на Х-Отчет в ОФД");
                await HttpService.Post(request);
            }
            catch (Exception e)
            {
                Log.Error(e.Message);
            }
            
        }
    }
}