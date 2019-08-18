using HSCFiscalRegistrar.Enums;
using HSCFiscalRegistrar.Models.DateTime;

namespace HSCFiscalRegistrar.DTO.RequestForOFD.ReportRequest
{
    public class ReportRequest : DateTime
    {
        public ReportTypeEnum Report { get; set; }
        public bool IsOffline { get; set; }
    }
}