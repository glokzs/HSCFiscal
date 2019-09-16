using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Cashboxes
{
    public class DtoToken
    {
        [JsonProperty("Token")]
        public string Token { get; set; }
    }
}