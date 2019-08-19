using System.Collections.Generic;
using System.Collections.Specialized;
using HSCFiscalRegistrar.DTO.RequestForOFD.MoneyPlacementRequest;
using HSCFiscalRegistrar.Models.DateTime;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace HSCFiscalRegistrar.DTO.RequestForOFD.ZXReport
{
    public class ZXReport : DateTime
    {
        public int ShiftNumber { get; set; }
        public List<> Sections { get; set; }
        public List<Operation> Operations { get; set; }
        public List<Operation> Discounts { get; set; }
        public List<Operation> Markups { get; set; }
        public List<Operation> TotalResult { get; set; }
        public List<Tax> Taxes { get; set; }
        public List<NonNullableSum> StartShiftNonNullableSums { get; set; }
        public List<TicketOperation> TicketOperations { get; set; }
        public MoneyPlacementZX MoneyPlacements { get; set; }
        public AnnulledTickets AnnulledTickets { get; set; }
        public Money CashSum { get; set; }
        public Revenue Revenue { get; set; }
        public List<NonNullableSum> NonNullableSums { get; set; }
        
        
        
    }
}