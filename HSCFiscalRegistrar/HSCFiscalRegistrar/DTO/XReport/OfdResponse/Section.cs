using System.Collections.Generic;

namespace HSCFiscalRegistrar.DTO.XReport.OfdResponse
{
    public class Section
    {
        public string SectionCode { get; set; }
        public List<Operation> Operations { get; set; }
        
    }
}