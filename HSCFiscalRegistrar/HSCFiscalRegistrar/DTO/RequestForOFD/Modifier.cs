using System.Collections.Generic;

namespace HSCFiscalRegistrar.DTO.RequestForOFD
{
    public class Modifier
    {
        public Money Sum { get; set; }
        public List<TicketRequest> Taxes { get; set; }
    }
}