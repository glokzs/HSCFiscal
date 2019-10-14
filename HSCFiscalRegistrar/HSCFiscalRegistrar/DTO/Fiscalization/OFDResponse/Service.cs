using System.Collections.Generic;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Fiscalization.OFDResponse
{
    public class Service
    {
        [JsonProperty("auxiliary")]
        public List<Auxiliary> Auxiliary { get; set; }
    }
}