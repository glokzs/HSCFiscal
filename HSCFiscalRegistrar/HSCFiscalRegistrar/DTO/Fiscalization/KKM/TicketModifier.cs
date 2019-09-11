using HSCFiscalRegistrar.DTO.Fiscalization.OFD;
using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.Fiscalization.KKM
{
    public class TicketModifier
    {
        public int Sum { get; set; }
        public string Text { get; set; }
        public int Type { get; set; }
        public TaxTypeEnum TaxType{ get; set; }
        public int Tax { get; set; }
    }
}