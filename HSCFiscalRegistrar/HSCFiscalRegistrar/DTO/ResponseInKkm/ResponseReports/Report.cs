namespace HSCFiscalRegistrar.DTO.ResponseInKkm.ResponseReports
{
    public abstract class Report
    {
        public string TaxPayerName { get; set; }
        public string TaxPayerIN { get; set; }
        public bool TaxPayerVAT { get; set; }
        public string TaxPayerVATSeria { get; set; }
        public string TaxPayerVATNumber { get; set; }
        public int ReportNumber { get; set; }
        public string CashboxSN { get; set; }
        public string CashboxIN { get; set; }
        public string CashboxRN { get; set; }
        public System.DateTime StartOn { get; set; }
        public System.DateTime ReportOn { get; set; }
        public System.DateTime CloseOn { get; set; }
        public int CashierCode { get; set; }
        public int ShiftNumber { get; set; }
        public int DocumentCount { get; set; }
        public decimal PutMoneySum { get; set; }
        public decimal TakeMoneySum { get; set; }
        public int ControlSum { get; set; }
        public bool OfflineMode { get; set; }
        public bool CashboxOfflineMode { get; set; }
        public decimal SumInCashbox { get; set; }
        public Sell Sell { get; set; }
        public Buy Buy { get; set; }
        public ReturnCell ReturnCell { get; set; }
        public ReturnBuy ReturnBuy { get; set; }
        public EndNonNullable EndNonNullable { get; set; }
        public StartNonNullable StartNonNullable { get; set; }
    }
}