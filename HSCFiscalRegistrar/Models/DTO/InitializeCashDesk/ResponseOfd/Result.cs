using Newtonsoft.Json;

namespace Models.DTO.InitializeCashDesk.ResponseOfd
{
    public class Result
    {
        [JsonProperty("result_code")]
        public int ResultCode { get; set; }
    }
}