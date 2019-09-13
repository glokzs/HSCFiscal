using HSCFiscalRegistrar.Enums;
using HSCFiscalRegistrar.Models.APKInfo;

namespace HSCFiscalRegistrar.DTO.Fiscalization.OFD
{
    public class FiscalOfdRequest
    {
        public Request Request { get; set; }
        public Ticket Ticket { get; set; }
    }
}