using System;

namespace HSCFiscalRegistrar.DTO.Registration
{
    public class ResponseServerReg
    {
        public string Successful { get; set; }
        public Guid Token { get; set; }
    }
}