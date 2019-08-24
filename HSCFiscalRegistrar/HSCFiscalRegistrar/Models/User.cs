using System;
using Microsoft.AspNetCore.Identity;

namespace HSCFiscalRegistrar.Models
{
    public class User : IdentityUser
    {
        public Guid UserToken { get; set; }
        public int DeviceId { get; set; }
        public DateTime DateTimeCreationToken { get; set; }
    }
}