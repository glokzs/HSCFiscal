using Newtonsoft.Json;

namespace Models.DTO.Cashboxes
{
    public class DtoToken
    {
        [JsonProperty("Token")]
        public string Token { get; set; }
    }
}