using System;
using Microsoft.AspNetCore.Identity;

namespace HSCFiscalRegistrar.Models
{
    public class User : IdentityUser
    {
        public string UserToken { get; set; }
        public DateTime DateTimeCreationToken { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}