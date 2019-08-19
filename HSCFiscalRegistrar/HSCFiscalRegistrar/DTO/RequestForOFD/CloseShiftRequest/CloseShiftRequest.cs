using HSCFiscalRegistrar.DTO.DateAndTime;

namespace HSCFiscalRegistrar.DTO.RequestForOFD.CloseShiftRequest
{
    public class CloseShiftRequest : DateTime
    {
        public DateTime CloseType { get; set; }
        public bool IsOffline { get; set; }
        public int FrShiftNumber { get; set; }
        public bool WithdrawMoney { get; set; }
    }
}