using System;
using Microsoft.AspNetCore.Identity;

namespace HSCFiscalRegistrar.Models
{
    public class User : IdentityUser
    {
        public string Password { get; set; }
        public string UserToken { get; set; }
        public string DeviceId { get; set; }
        public DateTime DateTime { get; set; }
    }
}