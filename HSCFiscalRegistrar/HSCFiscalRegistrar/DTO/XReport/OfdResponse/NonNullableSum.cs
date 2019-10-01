using HSCFiscalRegistrar.Enums;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.XReport.OfdResponse
{
    public class NonNullableSum
    {
        [JsonProperty("operation")]
        public OperationTypeEnum Operation { get; set; }
        [JsonProperty("sum")]
        public Money Sum { get; set; }
    }
}