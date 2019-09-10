using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Cashboxes
{
    public class Wrapper
    {
        [JsonProperty("Data")]
        public Data Data { get; set; }
    }
}
