using HSCFiscalRegistrar.Enums;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.XReport.OfdResponse
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