using System;
using HSCFiscalRegistrar.Models.APKInfo;
using Microsoft.AspNetCore.Identity;

namespace HSCFiscalRegistrar.Models
{
    public class User : IdentityUser
    {
        public string UserToken { get; set; }
        public int DeviceId { get; set; }
        public DateTime DateTimeCreationToken { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Kkm Kkm { get; set; }
        public string KkmId { get; set; }
        public Org Org { get; set; }
        public string OrgId { get; set; }
    }
}