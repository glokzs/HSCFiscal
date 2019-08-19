using HSCFiscalRegistrar.DTO.DateAndTime;

namespace HSCFiscalRegistrar.DTO.RequestForHSC.CloseShift
{
    public class CloseShift
    {
        public bool IsOffline { get; set; }
        public int FrShiftNumber { get; set; }
        public DateTime DateTime { get; set; }
    }
}