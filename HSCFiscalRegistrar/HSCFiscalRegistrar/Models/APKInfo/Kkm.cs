using Newtonsoft.Json;

namespace HSCFiscalRegistrar.Models.APKInfo
{
    public class Kkm
    {
        public string Id { get; set; }
        public string SerialNumber { get; set; }
        [JsonProperty("PointOfPaymentNumber")]
        public string PointOfPayment { get; set; }
        public string FnsKkmId { get; set; }
        public string TerminalNumber { get; set; }
        public int DeviceId { get; set; }
        public int OfdToken { get; set; }
        public int ReqNum { get; set; } 
    }
}