using Models.DTO.XReport.OfdResponse;
using Models.Enums;
using Newtonsoft.Json;

namespace Models.DTO.CloseShift.OfdResponse
{
    public class Report
    {
        [JsonProperty("zx_report")]
        public ZXReport ZxReport { get; set; }
        [JsonProperty("report")]
        public ReportTypeEnum ReportType { get; set; }
    }
}