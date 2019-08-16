namespace HSCFiscalRegistrar.DTO.ResponseInKkm.ResponseReports
{
    public abstract class NonNullableApiModel
    {
        public decimal Sell { get; set; }
        public decimal Buy { get; set; }
        public decimal ReturnSell { get; set; }
        public decimal ReturnBuy { get; set; }
    }
}