namespace HSCFiscalRegistrar.Models.APKInfo
{
    public class RegInfo
    {
        public string Id { get; set; }
        public string OrgId { get; set; }
        public virtual Org Org { get; set; }
        public string KkmId { get; set; }
        public virtual Kkm Kkm { get; set; }
    }
}