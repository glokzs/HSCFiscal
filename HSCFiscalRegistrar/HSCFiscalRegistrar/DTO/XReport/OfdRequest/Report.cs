using HSCFiscalRegistrar.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HSCFiscalRegistrar.DTO.XReport
{
    public class Report
    {
        [JsonProperty("report")]
        public ReportTypeEnum ReportType { get; set; }
        [JsonProperty("date_time")]
        public DateAndTime.DateTime DateTime { get; set; }
        [JsonProperty("is_offline")]
        public bool IsOffline { get; set; }
    }
}