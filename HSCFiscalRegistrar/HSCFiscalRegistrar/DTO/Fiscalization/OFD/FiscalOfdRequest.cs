using HSCFiscalRegistrar.Enums;
using HSCFiscalRegistrar.Models.APKInfo;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Fiscalization.OFD
{
    public class FiscalOfdRequest
    {
        [JsonProperty("Command")]
        public int Command { get; set; }
        [JsonProperty("DeviceId")]
        public int DeviceId { get; set; }
        [JsonProperty("ReqNum")]
        public int ReqNum { get; set; }
        [JsonProperty("Token")]
        public int Token { get; set; }
        [JsonProperty("Service")]
        public Service Service { get; set; }
        [JsonProperty("Ticket")]
        public Ticket Ticket { get; set; }
    }
}