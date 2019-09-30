using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.XReport.OfdResponse
{
    public class Revenue
    {
        [JsonProperty("sum")]
        public Money Sum { get; set; }
        [JsonProperty("is_negative")]
        public bool IsNegative { get; set; }
    }
}