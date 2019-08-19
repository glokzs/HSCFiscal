using HSCFiscalRegistrar.DTO.RequestForOFD.MoneyPlacementRequest;
using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.RequestForOFD.ZXReport
{
    public class TicketOperation
    {
        public OperationTypeEnum Type { get; set; }
        public int TicketsTotalCount { get; set; }
        public int TicketsCount { get; set; }
        public Money TicketsSum { get; set; }
        public Payment Payments { get; set; }
    }
}