using Newtonsoft.Json;

namespace Models.DTO.Fiscalization.OFD
{
    public class Amount
    {
        [JsonProperty("Total")]
        public Sum Total { get; set; }
    }
}