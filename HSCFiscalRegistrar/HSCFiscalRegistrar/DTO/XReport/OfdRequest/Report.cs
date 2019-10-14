using HSCFiscalRegistrar.DTO.DateAndTime;
using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.XReport.OfdRequest
{
    public class Report
    {
        public ReportTypeEnum ReportType { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsOffline { get; set; }

        public Report(ReportTypeEnum reportType, DateTime dateTime, bool isOffline)
        {
            ReportType = reportType;
            DateTime = dateTime;
            IsOffline = isOffline;
        }
    }
}