using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Fiscalization.OFDResponse
{
    public class Result
    {
        [JsonProperty("result_code")]
        public int ResultCode { get; set; }
    }
}