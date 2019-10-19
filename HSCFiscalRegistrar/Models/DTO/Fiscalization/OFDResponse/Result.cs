using Newtonsoft.Json;

namespace Models.DTO.Fiscalization.OFDResponse
{
    public class Result
    {
        [JsonProperty("result_code")]
        public int ResultCode { get; set; }
    }
}