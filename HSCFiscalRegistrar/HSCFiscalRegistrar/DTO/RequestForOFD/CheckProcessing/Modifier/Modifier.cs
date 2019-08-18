using System.Collections.Generic;

namespace HSCFiscalRegistrar.DTO.RequestForOFD.CheckProcessing.Modifier
{
    public class Modifier
    {
        public MoneyPlacementRequest.Money Sum { get; set; }
        public List<TicketRequest> Taxes { get; set; }
    }
}