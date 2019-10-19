using Models.Enums;
using Newtonsoft.Json;

namespace Models.DTO.XReport.OfdResponse
{
    public class Operation
    {
        [JsonProperty("operation")]
        public OperationTypeEnum OperationType { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("sum")]
        public Money Sum { get; set; }
        
    }
}