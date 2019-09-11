using System.Collections.Generic;

namespace HSCFiscalRegistrar.DTO.Fiscalization
{
    public class StornoCommodity
    {
        public string Name { get; set; }
        public string SectionCode { get; set; }
        public int Quantity { get; set; }
        public Sum Price { get; set; }
        public Sum Sum { get; set; }
        public List<Tax> Taxes { get; set; }
    }
}