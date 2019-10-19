using System;
using Microsoft.AspNetCore.Identity;
using Models.APKInfo;
using Models.Enums;

namespace Models
{
    public class User : IdentityUser
    {
        public int Code { get; set; }
        public string UserToken { get; set; }
        public DateTime DateTimeCreationToken { get; set; }
        public DateTime ExpiryDate { get; set; }
        public virtual Kkm Kkm { get; set; }
        public string KkmId { get; set; }
        public string Id { get; set; }
        public string Okved { get; set; }
        public string Name { get; set; }
        public int TaxationType { get; set; }
        public string Inn { get; set; }
        public string Title { get; set; }
        public bool VAT { get; set; }
        public string VATSeria { get; set; }
        public string VATNumber { get; set; }
        public UserTypeEnum UserType { get; set; }
    }
}