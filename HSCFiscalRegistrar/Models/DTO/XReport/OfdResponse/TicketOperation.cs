using System.Collections.Generic;
using Models.Enums;
using Newtonsoft.Json;

namespace Models.DTO.XReport.OfdResponse
{
    public class TicketOperation
    {
        [JsonProperty("operation")]
        public OperationTypeEnum Operation { get; set; }
        [JsonProperty("tickets_total_count")]
        public int TicketsTotalCount { get; set; }
        [JsonProperty("tickets_count")]
        public int TicketsCount { get; set; }
        [JsonProperty("tickets_sum")]
        public Money TicketsSum { get; set; }
        [JsonProperty("payments")]
        public List<Payment> Payments { get; set; }
    }
}