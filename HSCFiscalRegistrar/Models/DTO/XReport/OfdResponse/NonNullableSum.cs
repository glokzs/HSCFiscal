using Models.Enums;
using Newtonsoft.Json;

namespace Models.DTO.XReport.OfdResponse
{
    public class NonNullableSum
    {
        [JsonProperty("operation")]
        public OperationTypeEnum Operation { get; set; }
        [JsonProperty("sum")]
        public Money Sum { get; set; }
    }
}