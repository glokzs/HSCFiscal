using System.Collections.Generic;
using HSCFiscalRegistrar.DTO.RequestForOFD.CheckProcessing;

namespace HSCFiscalRegistrar.DTO.RequestForOFD
{
    public class Modifier
    {
        public FinanceOperations.Money Sum { get; set; }
        public List<TicketRequest> Taxes { get; set; }
    }
}