using System.Collections.Generic;
using System.Collections.Specialized;
using HSCFiscalRegistrar.DTO.RequestForOFD.MoneyPlacementRequest;
using HSCFiscalRegistrar.Models.DateTime;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HSCFiscalRegistrar.DTO.RequestForOFD.ZXReport
{
    public class ZXReport : DateTime
    {
        public int ShiftNumber { get; set; }
        public List<BitVector32.Section> Sections { get; set; }
        public List<Operation> Operations { get; set; }
        public List<Operation> Discounts { get; set; }
        public List<Operation> Markups { get; set; }
        public List<Operation> TotalResult { get; set; }
        public List<Tax> Taxes { get; set; }
        public List<NonNullableSum> StartShiftNonNullableSums { get; set; }
        public List<TicketOperation> TicketOperations { get; set; }
        public MoneyPlacementZX Type { get; set; }
        
        
        
    }
}