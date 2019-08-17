using System.Collections.Generic;
using HSCFiscalRegistrar.DTO.RequestForOFD.FinanceOperations;
using HSCFiscalRegistrar.Enums;
using HSCFiscalRegistrar.Models.DateTime;

namespace HSCFiscalRegistrar.DTO.RequestForOFD.CheckProcessing
{
    public class TicketRequest : DateTime
    {
        public OperationTypeEnum Operation { get; set; }
        public Operator Operator { get; set; }
        public Domain Domain { get; set; }
        public List<Item> Items { get; set; }
        public List<Payment> Payments { get; set; }
        public List<Tax> Taxes { get; set; }
        public Amount Amounts { get; set; }
        public ExtensionOption ExtensionOptions { get; set; }
        public int OfflineTicketNumber { get; set; }
        public string PrintedTicket { get; set; }
        public string FrShiftNumber { get; set; }
    }
}