using HSCFiscalRegistrar.Enums;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.XReport.OfdResponse
{
    public class ZXOfdResponse
    {
        [JsonProperty("report")]
        public int Report { get; set; }
        [JsonProperty("zx_report")]
        public ZXReport ZXReport { get; set; }
    }
}