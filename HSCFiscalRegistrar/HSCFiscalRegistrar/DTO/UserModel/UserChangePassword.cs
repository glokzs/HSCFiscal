using System;

namespace HSCFiscalRegistrar.DTO.UserModel
{
    public class UserChangePassword : UserDTO
    {
        public int Command { get; set; }
        public string NewPassword { get; set; }
        public Guid Token { get; set; }
    }
}