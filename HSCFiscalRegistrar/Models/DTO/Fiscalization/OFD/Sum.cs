using Newtonsoft.Json;

namespace Models.DTO.Fiscalization.OFD
{
    public class Sum
    {
        [JsonProperty("Bills")]
        public decimal Bills { get; set; }
        [JsonProperty("Coins")]
        public decimal Coins { get; set; }
    }
}