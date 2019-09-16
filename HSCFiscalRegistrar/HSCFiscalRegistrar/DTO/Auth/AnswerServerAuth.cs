using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Auth
{
    public class AnswerServerAuth
    {
        [JsonProperty("Data")]
        public Data Data { get; set; }
    }
}