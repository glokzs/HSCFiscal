using System.Collections.Generic;
using HSCFiscalRegistrar.DTO.Fiscalization.OFD;
using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.Fiscalization.KKM
{
    public class Response
    {
        public string Token { get; set; }
        public string CashboxUniqueNumber { get; set; }
        public OperationTypeEnum OperationType { get; set; }
        public List<Position> Positions { get; set; }
        public List<TicketModifier> TicketModifiers { get; set; }
        public List<Payment> Payments { get; set; }
        public int Change { get; set; }
        public int RoundType { get; set; }
        public string ExternalCheckNumber { get; set; }
        public string CustomerEmail { get; set; }
    }
}