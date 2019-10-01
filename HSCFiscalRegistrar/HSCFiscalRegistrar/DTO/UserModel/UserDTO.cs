namespace HSCFiscalRegistrar.DTO.UserModel
{
    public class UserDTO
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public override string ToString()
        {
            return $"{Login}:{Password}";
        }
    }
}