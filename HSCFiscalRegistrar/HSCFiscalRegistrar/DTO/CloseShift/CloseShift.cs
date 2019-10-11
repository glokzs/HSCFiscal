namespace HSCFiscalRegistrar.DTO.CloseShift
{
    public class CloseShift
    {
        public bool IsOffline { get; set; }
        public int FrShiftNumber { get; set; }
        public DateAndTime.DateTime DateTime { get; set; }
        
    }
}