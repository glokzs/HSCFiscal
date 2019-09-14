using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Fiscalization.OFD
{
    public class Sum
    {
        [JsonProperty("Bills")]
        public decimal Bills { get; set; }
        [JsonProperty("Coins")]
        public decimal Coins { get; set; }
    }
}