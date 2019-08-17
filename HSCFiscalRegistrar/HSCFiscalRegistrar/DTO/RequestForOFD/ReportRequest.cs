using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.RequestForOFD
{
    public class ReportRequest
    {
        public ReportTypeEnum Report { get; set; }
        public bool IsOffline { get; set; }
    }
}