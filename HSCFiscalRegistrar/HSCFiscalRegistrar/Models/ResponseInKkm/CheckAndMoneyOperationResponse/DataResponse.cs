namespace HSCFiscalRegistrar.Models.ResponseInKkm.CheckAndMoneyOperationResponse
{
    public abstract class DataResponse
    {
        public string Id { get; set; }
        public string CheckNumber { get; set; }
        public System.DateTime DateTime { get; set; }
        public bool OfflineMode { get; set; }
        public bool CashboxOfflineMode { get; set; }
        public string CashboxId { get; set; }

        public virtual Cashbox Cashbox { get; set; }
    }
}