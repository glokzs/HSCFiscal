namespace HSCFiscalRegistrar.DTO.ResponseInKkm.CheckAndMoneyOperationResponse
{
    public abstract class DataResponse
    {
        public string CheckNumber { get; set; }
        public System.DateTime DateTime { get; set; }
        public bool OfflineMode { get; set; }
        public bool CashboxOfflineMode { get; set; }
        public  Cashbox Cashbox { get; set; }
    }
}