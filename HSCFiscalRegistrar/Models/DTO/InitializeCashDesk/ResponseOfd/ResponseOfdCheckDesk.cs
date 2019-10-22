using Newtonsoft.Json;
using Models.DTO.InitializeCashDesk.ResponseOfd;

namespace Models.DTO.InitializeCashDesk.ResponseOfd
{
    public class ResponseOfdCheckDesk
    {
        [JsonProperty("result")]
        public Result Result { get; set; }
        [JsonProperty("service")] 
        public ServiceOfdDesk ServiceOfdDesk { get; set; }
        [JsonProperty("command")]
        public string Command { get; set; }
        [JsonProperty("token")]
        public int TokenOfd { get; set; }
    }
}