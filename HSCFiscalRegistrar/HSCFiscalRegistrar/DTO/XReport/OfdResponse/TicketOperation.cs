using System.Collections.Generic;
using HSCFiscalRegistrar.Enums;
using HSCFiscalRegistrar.Models.Transaction;

namespace HSCFiscalRegistrar.DTO.XReport.OfdResponse
{
    public class TicketOperation
    {
        public OperationTypeEnum Operation { get; set; }
        public int TicketsTotalCount { get; set; }
        public int TicketsCount { get; set; }
        public int TicketsSum { get; set; }
        public List<Payment> Payments { get; set; }
    }
}