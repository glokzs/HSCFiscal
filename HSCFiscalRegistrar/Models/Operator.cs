using System;
using Models.APKInfo;

namespace Models
{
    public class Operator
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public virtual User User { get; set; }
        public string UserId { get; set; }
        
        public string UserToken { get; set; }
        
        public DateTime DateTimeCreationToken { get; set; }
        
        public DateTime ExpiryDate { get; set; }
        public virtual Kkm Kkm { get; set; }
        public string KkmId { get; set; }
        public virtual Org Org { get; set; }
        public string OrgId { get; set; }
    }
}