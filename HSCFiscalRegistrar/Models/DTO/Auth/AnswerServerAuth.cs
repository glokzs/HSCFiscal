using Newtonsoft.Json;

namespace Models.DTO.Auth
{
    public class AnswerServerAuth
    {
        [JsonProperty("Data")]
        public Data Data { get; set; }
    }
}