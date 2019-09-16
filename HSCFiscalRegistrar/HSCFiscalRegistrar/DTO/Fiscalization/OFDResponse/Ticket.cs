using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Fiscalization.OFDResponce
{
    public class Ticket
    {
        [JsonProperty("qr_code")]
        public string QrCode { get; set; }
        [JsonProperty("ticket_number")]
        public string TicketNumber { get; set; }
        
    }
}