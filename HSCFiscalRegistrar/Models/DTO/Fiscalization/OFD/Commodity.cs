using Newtonsoft.Json;

namespace Models.DTO.Fiscalization.OFD
{
    public class Commodity : StornoCommodity
    {
        [JsonProperty("Code")]
        public int Code { get; set; }
    }
}