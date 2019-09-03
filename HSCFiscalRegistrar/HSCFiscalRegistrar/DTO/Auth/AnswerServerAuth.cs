using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Data
{
    public class AnswerServerAuth
    {
        [JsonProperty("Data")]
        public Data Data { get; set; }
    }
}