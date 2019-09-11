using System.Collections.Generic;

namespace HSCFiscalRegistrar.DTO.Fiscalization.OFD
{
    public class Markup
    {
        public string Name { get; set; }
        public Sum Sum { get; set; }
        public List<Tax> Taxes { get; set; }
    }
}