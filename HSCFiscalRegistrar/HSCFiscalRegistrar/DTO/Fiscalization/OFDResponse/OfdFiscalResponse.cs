using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Fiscalization.OFDResponse
{
    public class OfdFiscalResponse
    {
        [JsonProperty("result")]
        public Result Result { get; set; }
        [JsonProperty("ticket")]
        public Ticket Ticket { get; set; }
        [JsonProperty("service")]
        public Service Service { get; set; }
        [JsonProperty("command")]
        public string Command { get; set; }
        [JsonProperty("token")]
        public int Token { get; set; }
    }
}