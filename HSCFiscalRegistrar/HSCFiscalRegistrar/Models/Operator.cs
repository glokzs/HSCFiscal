using HSCFiscalRegistrar.Models.APKInfo;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HSCFiscalRegistrar.Models
{
    public class Operator
    {
        public string Id { get; set; }
        public virtual User User { get; set; }
        public string UserId { get; set; }
        public virtual Kkm Kkm { get; set; }
        public string KkmId { get; set; }
        public virtual Org Org { get; set; }
        public string OrgId { get; set; }
    }
}