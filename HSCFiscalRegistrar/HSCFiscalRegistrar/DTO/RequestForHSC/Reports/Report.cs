using HSCFiscalRegistrar.DTO.DateAndTime;
using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.RequestForHSC.Reports
{
    public class Report
    {
        public ReportTypeEnum ReportTypeEnum { get; set; }
        public DateTime  DateTime { get; set; }
    }
}