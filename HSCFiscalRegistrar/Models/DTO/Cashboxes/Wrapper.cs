using Newtonsoft.Json;

namespace Models.DTO.Cashboxes
{
    public class Wrapper
    {
        [JsonProperty("Data")]
        public Data Data { get; set; }
    }
}
