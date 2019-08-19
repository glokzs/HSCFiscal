using HSCFiscalRegistrar.DTO.DateAndTime;
using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.RequestForOFD.ReportRequest
{
    public class ReportRequest : DateTime
    {
        public ReportTypeEnum Report { get; set; }
        public bool IsOffline { get; set; }
    }
}