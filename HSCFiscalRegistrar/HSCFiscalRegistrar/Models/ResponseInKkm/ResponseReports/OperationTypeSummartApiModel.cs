namespace HSCFiscalRegistrar.Models.ResponseInKkm.ResponseReports
{
    public abstract class OperationTypeSummartApiModel
    {
        public string Id { get; set; }
        public string PaymentsByTypesApiModelId { get; set; }
        public decimal Discount { get; set; }
        public decimal Markup { get; set; }
        public decimal Taken { get; set; }
        public decimal Change { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public decimal VAT { get; set; }

        public PaymentsByTypesApiModel PaymentsByTypesApiModel { get; set; }
    }
}