using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Fiscalization.OFD
{
    public class Operator
    {
        [JsonProperty("Code")]
        public int Code { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
    }
}