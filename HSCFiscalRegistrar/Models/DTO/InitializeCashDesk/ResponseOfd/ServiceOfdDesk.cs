using Newtonsoft.Json;

namespace Models.DTO.InitializeCashDesk.ResponseOfd
{
    public class ServiceOfdDesk
    {
        [JsonProperty("reg_info")]
        public RegInfoOfdDesk RegInfoOfdDesk { get; set; }
    }
}