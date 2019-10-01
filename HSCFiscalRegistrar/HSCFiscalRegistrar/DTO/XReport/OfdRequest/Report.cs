using HSCFiscalRegistrar.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HSCFiscalRegistrar.DTO.XReport
{
    public class Report
    {
        public ReportTypeEnum ReportType { get; set; }
        public DateAndTime.DateTime DateTime { get; set; }
        public bool IsOffline { get; set; }
    }
}