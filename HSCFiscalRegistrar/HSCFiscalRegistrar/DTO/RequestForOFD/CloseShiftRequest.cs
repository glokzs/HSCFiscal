using HSCFiscalRegistrar.Models.DateTime;

namespace HSCFiscalRegistrar.DTO.RequestForOFD
{
    public class CloseShiftRequest : DateTime
    {
        public DateTime CloseType { get; set; }
        public bool IsOffline { get; set; }
        public int FrShiftNumber { get; set; }
        public bool WithdrawMoney { get; set; }
    }
}