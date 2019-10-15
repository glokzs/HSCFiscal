using Models.Enums;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.XReport.OfdResponse
{
    public class MoneyPlacement
    {
        [JsonProperty("operation")]
        public MoneyPlacementEnum Operation { get; set; }
        [JsonProperty("operations_total_count")]
        public int OperationsTotalCount { get; set; }
        [JsonProperty("operations_count")]
        public int OperationsCount { get; set; }
        [JsonProperty("operations_sum")]
        public Money OperationsSum { get; set; }
        
    }
}