using Models.Enums;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Fiscalization.OFD
{
    public class Domain
    {
        [JsonProperty("Type")]
        public DomainTypeEnum Type { get; set; }
    }
}