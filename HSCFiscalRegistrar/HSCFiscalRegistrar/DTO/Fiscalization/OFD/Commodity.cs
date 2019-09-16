using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Fiscalization.OFD
{
    public class Commodity : StornoCommodity
    {
        [JsonProperty("Code")]
        public int Code { get; set; }
    }
}