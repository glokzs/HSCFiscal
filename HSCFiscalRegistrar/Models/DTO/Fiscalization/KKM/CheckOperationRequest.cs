using System.Collections.Generic;
using Models.Enums;
using Newtonsoft.Json;

namespace Models.DTO.Fiscalization.KKM
{
    public class CheckOperationRequest
    {
        [JsonProperty("Token")] 
        public string Token { get; set; }
        [JsonProperty("CashboxUniqueNumber")] 
        public string CashboxUniqueNumber { get; set; }
        [JsonProperty("OperationType")]
        public OperationTypeEnum OperationType { get; set; }
        [JsonProperty("Positions")]
        public List<PositionType> Positions = new List<PositionType>();
        [JsonProperty("TicketModifiers")]
        public List<TicketModifierType> TicketModifiers = new List<TicketModifierType>();
        [JsonProperty("Payments")]
        public List<PaymentsType> Payments = new List<PaymentsType>();
        [JsonProperty("Change")]
        public decimal Change { get; set; }
        [JsonProperty("RoundType")]
        public int RoundType { get; set; }
        [JsonProperty("ExternalCheckNumber")]
        public string ExternalCheckNumber { get; set; }
        [JsonProperty("CustomerEmail")]
        public string CustomerEmail { get; set; }
        public override string ToString()
        {
            return $"{Token}";
        }
    }
}