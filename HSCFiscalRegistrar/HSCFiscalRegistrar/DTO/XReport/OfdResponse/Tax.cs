using System.Collections.Generic;
using Models.Enums;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.XReport.OfdResponse
{
    public class Tax
    {
        [JsonProperty("type")]
        public TaxTypeEnum Type { get; set; }
        [JsonProperty("percent")]
        public int Percent { get; set; }
        [JsonProperty("operations")]
        public List<TaxOperation> Operations { get; set; } 
    }
}