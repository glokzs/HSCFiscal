using Models.Enums;
using Newtonsoft.Json;

namespace Models.DTO.XReport.OfdResponse
{
    public class ZXOfdResponse
    {
        [JsonProperty("zx_report")]
        public ZXReport ZXReport { get; set; }
        [JsonProperty("report")]
        public ReportTypeEnum Report { get; set; }
    }
}