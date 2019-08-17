using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.ResponseFromHSC.Reports
{
    public class Report
    {
        public ZXReport ZxReport { get; set; }
        public ReportTypeEnum Reports { get; set; }
    }
}
