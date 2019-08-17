using System.Collections.Generic;
using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.ResponseFromHSC.Reports.TicketOperations
{
    public class TicketOperation
    {
        public int TicketsCount { get; set; }
        public int TicketsTotalCount { get; set; }
        public List<Payment> Payments { get; set; }
        public OperationTypeEnum OperationEnum { get; set; }
        public TicketSum TicketSum { get; set; }
    }
}