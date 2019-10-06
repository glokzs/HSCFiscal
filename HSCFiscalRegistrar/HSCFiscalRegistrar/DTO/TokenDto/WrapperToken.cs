using HSCFiscalRegistrar.DTO.Auth;

namespace HSCFiscalRegistrar.DTO.TokenDto
{
    public class WrapperToken
    {
        public string Token { get; set; }
        public string CashboxUniqueNumber { get; set; }
    }
}