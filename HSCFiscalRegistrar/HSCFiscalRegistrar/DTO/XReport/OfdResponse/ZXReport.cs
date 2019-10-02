using System.Collections.Generic;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.XReport.OfdResponse
{
    public class ZXReport
    {
        [JsonProperty("date_time")]
        public DateAndTime.DateTime DateTime { get; set; }
        [JsonProperty("shift_number")]
        public int ShiftNumber { get; set; }
        [JsonProperty("sections")]
        public List<Section> Sections { get; set; }
        [JsonProperty("operations")]
        public List<Operation> Operations { get; set; }
        [JsonProperty("discounts")]
        public List<Operation> Discounts { get; set; }
        [JsonProperty("markups")]
        public List<Operation> Markups{ get; set; }
        [JsonProperty("total_result")]
        public List<Operation> TotalResult { get; set; }
        [JsonProperty("taxes")]
        public List<Tax> Taxes { get; set; }
        [JsonProperty("start_shift_non_nullable_sums")]
        public List<NonNullableSum> StartShiftNonNullableSums { get; set; }
        [JsonProperty("ticket_operations")]
        public List<TicketOperation> TicketOperations { get; set; }
        [JsonProperty("money_placements")]
        public List<MoneyPlacement> MoneyPlacements { get; set; }
        [JsonProperty("annulled_tickets")]
        public AnnulledTickets AnnulledTickets { get; set; }
        [JsonProperty("cash_sum")]
        public Money CashSum { get; set; }
        [JsonProperty("revenue")]
        public Revenue Revenue { get; set; }
        [JsonProperty("non_nullable_sums")]
        public List<NonNullableSum> NonNullableSums { get; set; }
    }
}