namespace HSCFiscalRegistrar.DTO.RequestFromKKM
{
    public abstract class DataRequest
    {
        public string Token { get; set; }
        public string CashboxUniqueNumber { get; set; }
        public long TypeOperation { get; set; }
        public string ExternalCheckNumber { get; set; }
    }
}