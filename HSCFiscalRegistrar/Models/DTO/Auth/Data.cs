using Newtonsoft.Json;

namespace Models.DTO.Auth
{
    public class Data
    {
        [JsonProperty("Token")]
        public string Token { get; set; }
    }
}