namespace HSCFiscalRegistrar.DTO.RequestForOFD
{
    public class CloseShiftRequest
    {
        public Models.DateTime.DateTime CloseType { get; set; }
        public bool IsOffline { get; set; }
        public int FrShiftNumber { get; set; }
        public bool WithdrawMoney { get; set; }
    }
}