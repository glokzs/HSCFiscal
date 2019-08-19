using System.Collections.Generic;

namespace HSCFiscalRegistrar.DTO.RequestForOFD.ZXReport
{
    public class AnnulledTickets
    {
        public int AnnulledTicketsTotalCount { get; set; }
        public int AnnulledTicketsCount { get; set; }
        public List<OperationZX> Type { get; set; }
        
    }
}