namespace HSCFiscalRegistrar.Models.APKInfo
{
    public class Service
    {
        public string Id { get; set; }
        public string RegInfoId { get; set; }
        public virtual RegInfo RegInfo { get; set; }
    }
}