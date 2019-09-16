using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Fiscalization.OFD
{
    public class Amount
    {
        [JsonProperty("Total")]
        public Sum Total { get; set; }
    }
}