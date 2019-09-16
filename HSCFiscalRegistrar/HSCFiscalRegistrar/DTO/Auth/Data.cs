using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Auth
{
    public class Data
    {
        [JsonProperty("Token")]
        public string Token { get; set; }
    }
}