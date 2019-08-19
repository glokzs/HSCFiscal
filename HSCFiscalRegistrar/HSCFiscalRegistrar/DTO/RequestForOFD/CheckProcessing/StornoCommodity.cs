using System.Collections.Generic;
using HSCFiscalRegistrar.DTO.RequestForOFD.MoneyPlacementRequest;

namespace HSCFiscalRegistrar.DTO.RequestForOFD.CheckProcessing
{
    public class StornoCommodity : Finance.Finance
    {
        public string Name { get; set; }
        public string SectionCode { get; set; }
        public int Quantity { get; set; }
        public Money Price { get; set; }
        public List<Tax> Type { get; set; }
        
        
    }
}