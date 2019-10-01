namespace HSCFiscalRegistrar.DTO.Registration
{
    public class UserRegistration
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public override string ToString()
        {
            return $"{Login}:{Password}";
        }
    }
}