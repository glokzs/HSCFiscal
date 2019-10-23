using Models.Enums;
using Newtonsoft.Json;

namespace Models.DTO.XReport.OfdResponse
{
    public class TaxOperation
    {
        [JsonProperty("operation")]
        public OperationTypeEnum Operation{ get; set; }
        [JsonProperty("turnover")]
        public Money Turnover { get; set; }
        [JsonProperty("sum")]
        public Money Sum { get; set; }    
        
    }
}