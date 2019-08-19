using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace HSCFiscalRegistrar.DTO.RequestForOFD.ZXReport
{
    public class AnnulledTickets
    {
        public int AnnulledTicketsTotalCount { get; set; }
        public int AnnulledTicketsCount { get; set; }
        public List<> Type { get; set; }
    }
}