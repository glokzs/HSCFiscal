using System.Collections.Generic;
using HSCFiscalRegistrar.DTO.DateAndTime;
using HSCFiscalRegistrar.DTO.RequestForOFD.Customer;
using HSCFiscalRegistrar.DTO.RequestForOFD.MoneyPlacementRequest;
using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.RequestForOFD.CheckProcessing
{
    public class TicketRequest : DateTime
    {
        public OperationTypeEnum Operation { get; set; }
        public Operator.Operator Operator { get; set; }
        public Domain.Domain Domain { get; set; }
        public List<Item.Item> Items { get; set; }
        public List<Payment> Payments { get; set; }
        public List<Tax> Taxes { get; set; }
        public Amount Amounts { get; set; }
        public ExtensionOption ExtensionOptions { get; set; }
        public int OfflineTicketNumber { get; set; }
        public string PrintedTicket { get; set; }
        public string FrShiftNumber { get; set; }
    }
}