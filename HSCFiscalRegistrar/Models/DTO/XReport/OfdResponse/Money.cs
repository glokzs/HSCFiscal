using Newtonsoft.Json;

namespace Models.DTO.XReport.OfdResponse
{
    public class Money
    {
        [JsonProperty("bills")]
        public int Bills { get; set; }
        [JsonProperty("coins")]
        public int Coins { get; set; }
    }
}