using System.Collections.Generic;
using HSCFiscalRegistrar.DTO.Fiscalization.OFD;
using HSCFiscalRegistrar.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HSCFiscalRegistrar.DTO.Fiscalization.KKM
{
    public class CheckOperationRequest
    {
        [JsonProperty("Token")] 
        public string Token { get; set; }
        [JsonProperty("CashboxUniqueNumber")] 
        public string CashboxUniqueNumber { get; set; }
        [JsonProperty("OperationType")]
        public int OperationType { get; set; }
        [JsonProperty("Positions")]
        public List<PositionType> Positions = new List<PositionType>();
        [JsonProperty("TicketModifiers")]
        public List<TicketModifierType> TicketModifiers = new List<TicketModifierType>();
        [JsonProperty("Payments")]
        public List<PaymentsType> Payments = new List<PaymentsType>();
        [JsonProperty("Change")]
        public int Change { get; set; }
        [JsonProperty("RoundType")]
        public int RoundType { get; set; }
        [JsonProperty("ExternalCheckNumber")]
        public string ExternalCheckNumber { get; set; }
        [JsonProperty("CustomerEmail")]
        public string CustomerEmail { get; set; }
    }
}