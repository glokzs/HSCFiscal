using System.Collections.Generic;

namespace HSCFiscalRegistrar.DTO.XReport.OfdResponse
{
    public class AnnulledTickets
    {
        public int AnnulledTicketsTotalCount { get; set; }
        public int AnnulledTicketsCount { get; set; }
        public List<Operation> AnnulledOperations { get; set; }
        
    }
}