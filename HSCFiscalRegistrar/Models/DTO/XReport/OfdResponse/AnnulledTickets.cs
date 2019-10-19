using System.Collections.Generic;
using Newtonsoft.Json;

namespace Models.DTO.XReport.OfdResponse
{
    public class AnnulledTickets
    {
        [JsonProperty("annulled_tickets_total_count")]
        public int AnnulledTicketsTotalCount { get; set; }
        [JsonProperty("annulled_tickets_count")]
        public int AnnulledTicketsCount { get; set; }
        [JsonProperty("annulled_operations")]
        public List<Operation> AnnulledOperations { get; set; }
        
    }
}