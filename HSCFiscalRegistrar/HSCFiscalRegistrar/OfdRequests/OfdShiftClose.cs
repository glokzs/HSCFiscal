using System;
using HSCFiscalRegistrar.DTO.CloseShift;
using HSCFiscalRegistrar.Models.APKInfo;
using HSCFiscalRegistrar.Services;

namespace HSCFiscalRegistrar.OfdRequests
{
    public class OfdShiftClose
    {
        public async void Request(Kkm kkm, Org org, int shiftNumber)
        {
            var closeShiftRequest = new CloseShiftRequest(kkm, org, shiftNumber);
            try
            {
                await HttpService.Post(closeShiftRequest);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}