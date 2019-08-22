using System;

namespace HSCFiscalRegistrar.DTO.UserModel
{
    public class Data
    {
        public Guid UserToken { get; set; }
        public int DeviceId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime DateTime { get; set; }

       
    }
}