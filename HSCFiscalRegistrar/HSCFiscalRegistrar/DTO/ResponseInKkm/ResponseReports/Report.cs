namespace HSCFiscalRegistrar.DTO.ResponseInKkm.ResponseReports
{
    public abstract class Report
    {
        public string Id { get; set; }
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
        public string SellId { get; set; }
        public string BuyId { get; set; }
        public string ReturnCellId { get; set; }
        public string ReturnBuyId { get; set; }
        public string EndNonNullableId { get; set; }
        public string StartNonNullableId { get; set; }

        public virtual Sell Sell { get; set; }
        public virtual Buy Buy { get; set; }
        public virtual ReturnBuy ReturnBuy { get; set; }
        public virtual ReturnCell ReturnCell { get; set; }
        public virtual EndNonNullable EndNonNullable { get; set; }
        public virtual StartNonNullable StartNonNullable { get; set; }

    }
}