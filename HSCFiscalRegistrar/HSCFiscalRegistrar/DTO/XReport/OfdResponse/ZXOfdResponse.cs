using HSCFiscalRegistrar.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HSCFiscalRegistrar.DTO.XReport.OfdResponse
{
    public class ZXOfdResponse
    {
        [JsonProperty("zx_report")]
        public ZXReport ZXReport { get; set; }
        [JsonProperty("report")]
        public ReportTypeEnum Report { get; set; }
    }
}