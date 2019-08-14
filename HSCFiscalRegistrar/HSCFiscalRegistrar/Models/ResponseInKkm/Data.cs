namespace HSCFiscalRegistrar.Models.ResponseInKkm
{
    public class Data
    {
        public string CheckNumber { get; set; }
        public System.DateTime DateTime { get; set; }
        public bool OfflineMode { get; set; }
        public bool CashboxOfflineMode { get; set; }
        public string CashboxId { get; set; }

        public virtual Cashbox Cashbox { get; set; }
    }
}