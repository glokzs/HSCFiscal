using System.Collections.Generic;
using System.Collections.Specialized;
using HSCFiscalRegistrar.DTO.Fiscalization.OFD;

namespace HSCFiscalRegistrar.DTO.XReport.OfdResponse
{
    public class ZXReport
    {
        public DateAndTime.DateTime DateTime { get; set; }
        public int ShiftNumber { get; set; }
        public List<Section> Sections { get; set; }
        public List<Operation> Operations { get; set; }
        public List<Operation> Discounts { get; set; }
        public List<Operation> Markups { get; set; }
        public List<Operation> TotalResult { get; set; }
        public List<Tax> Taxes { get; set; }
        public List<NonNullableSum> StartShiftNonNullableSums { get; set; }
        public List<TicketOperation> TicketOperations { get; set; }
        public List<MoneyPlacement> MoneyPlacements { get; set; }
        public AnnulledTickets AnnulledTickets { get; set; }
        public Money CashSum { get; set; }
        public Revenue Revenue { get; set; }
        public List<NonNullableSum> NonNullableSums { get; set; }
        
        
    }
}