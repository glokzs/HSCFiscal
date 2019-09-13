using System.Collections.Generic;
using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.Fiscalization.OFD
{
    public class Ticket
    {
        public OperationTypeEnum Operation { get; set; }
        public Operator Operator { get; set; }
        public DateAndTime.DateTime DateTime { get; set; }
        public Amount Amounts { get; set; }
        public List<Payment> Payments { get; set; }
        public List<Item> Items { get; set; }
        public Domain Domain { get; set; }
        
    }
}