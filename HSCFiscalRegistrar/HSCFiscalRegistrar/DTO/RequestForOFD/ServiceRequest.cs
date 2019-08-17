using System.Collections.Generic;

namespace HSCFiscalRegistrar.DTO.RequestForOFD
{
    public class ServiceRequest
    {
        public CommQuality CommQuality { get; set; }
        public SoftwareInformation software_information { get; set; }
        public SecurityStats Type { get; set; }
        public OflinePeriod OfflinePeriod { get; set; }
        public int NomenclatureVersion { get; set; }
        public List<TicketAdInfo> TicketAdInfos { get; set; }
        public bool GetRegInfo { get; set; }
        public bool GetBindedTaxation { get; set; }
        public Auxiliary Auxiliary { get; set; }
        public RegInfo RegInfo { get; set; }

        
    }
}