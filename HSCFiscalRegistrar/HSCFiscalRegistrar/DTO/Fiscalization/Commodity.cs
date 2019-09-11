using System.Collections.Generic;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace HSCFiscalRegistrar.DTO.Fiscalization
{
    public class Commodity : StornoCommodity
    {
        public int Code { get; set; }
    }
}