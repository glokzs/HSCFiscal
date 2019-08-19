using System.Collections.Generic;
using HSCFiscalRegistrar.DTO.RequestForOFD.CheckProcessing;
using HSCFiscalRegistrar.DTO.RequestForOFD.ServiceRequest.Device;
using HSCFiscalRegistrar.DTO.ResponseFromHSC;

namespace HSCFiscalRegistrar.DTO.RequestForOFD.ServiceRequest
{
    public class ServiceRequest
    {
        public CommQuality CommQuality { get; set; }
        public SoftwareInformation SoftwareInformation { get; set; }
        //public SecurityStats SecurityStats { get; set; }
        public OflinePeriod OfflinePeriod { get; set; }
        public int NomenclatureVersion { get; set; }
        public List<TicketAdInfo> TicketAdInfos { get; set; }
        public bool GetRegInfo { get; set; }
        public bool GetBindedTaxation { get; set; }
        public Auxiliary Auxiliary { get; set; }
        public Device.RegInfo RegInfo { get; set; }

        
    }
}