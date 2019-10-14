using System.Collections.Generic;
using HSCFiscalRegistrar.Enums;
using HSCFiscalRegistrar.Models;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.Fiscalization.OFD
{
    public class Ticket
    {
        [JsonProperty("Operation")]
        public OperationTypeEnum Operation { get; set; }
        [JsonProperty("Operator")]
        public Operator Operator { get; set; }
        [JsonProperty("DateTime")]
        public DateAndTime.DateTime DateTime { get; set; }
        [JsonProperty("Amounts")]
        public Amount Amounts { get; set; }
        [JsonProperty("Payments")]
        public List<Payment> Payments { get; set; }
        [JsonProperty("Items")]
        public List<Item> Items { get; set; }
        [JsonProperty("Domain")]
        public Domain Domain { get; set; }
        [JsonProperty("OfflineTicketNumber")]
        public string OfflineTicketNumber { get; set; }
    }
}