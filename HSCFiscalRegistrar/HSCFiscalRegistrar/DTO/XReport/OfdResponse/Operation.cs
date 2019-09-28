using HSCFiscalRegistrar.Enums;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.XReport.OfdResponse
{
    public class Operation
    {
        [JsonProperty("operation")]
        public OperationTypeEnum OperationType { get; set; }
        public int Count { get; set; }
        public Money Sum { get; set; }
        
    }
}