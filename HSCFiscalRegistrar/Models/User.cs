using System;
using Microsoft.AspNetCore.Identity;
using Models.Enums;

namespace Models
{
    public class User : IdentityUser
    {
        public int OperatorCode { get; set; }
        public string UserToken { get; set; }
        public DateTime DateTimeCreationToken { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Okved { get; set; }
        public TaxationTypeEnum TaxationType { get; set; }
        public string Inn { get; set; }

        public string OwnerId { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public bool VAT { get; set; }
        public string VATSeria { get; set; }
        public string VATNumber { get; set; }
        public UserTypeEnum UserType { get; set; }
        public string Fio { get; set; }
    }
}