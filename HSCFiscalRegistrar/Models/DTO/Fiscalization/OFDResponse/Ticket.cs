using Newtonsoft.Json;

namespace Models.DTO.Fiscalization.OFDResponse
{
    public class Ticket
    {
        [JsonProperty("qr_code")]
        public string QrCode { get; set; }
        [JsonProperty("ticket_number")]
        public string TicketNumber { get; set; }
        
    }
}