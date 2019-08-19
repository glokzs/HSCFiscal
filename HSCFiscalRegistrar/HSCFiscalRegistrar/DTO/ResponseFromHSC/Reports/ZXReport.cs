using System.Collections.Generic;
using HSCFiscalRegistrar.DTO.DateAndTime;
using HSCFiscalRegistrar.DTO.ResponseFromHSC.Reports.MoneyPlacements;
using HSCFiscalRegistrar.DTO.ResponseFromHSC.Reports.Taxes;
using HSCFiscalRegistrar.DTO.ResponseFromHSC.Reports.TicketOperations;
using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.ResponseFromHSC.Reports
{
    public class ZXReport
    {
        public Operation TotalResult { get; set; }
        public List<NonNullableSum> NonNullableSums { get; set; }
        public Tax Taxes { get; set; }
        public CashSum CashSum { get; set; }
        public int ShiftNumber { get; set; }
        public Revenue Revenue { get; set; }
        public Operation Operations { get; set; }
        public DateTime DateTime { get; set; }
        public List<StartShiftNonNullableSum> StartShiftNonNullableSums { get; set; }
        public List<TicketOperation> TicketOperations { get; set; }
        public List<MoneyPlacement> MoneyPlacements { get; set; }
        public AnulledTicket AnulledTickets { get; set; }
        public Operation Discounts { get; set; }
        public Operation Markups { get; set; }
    }
}