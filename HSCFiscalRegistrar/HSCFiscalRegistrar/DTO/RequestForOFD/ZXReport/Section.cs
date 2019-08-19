using System.Collections.Generic;

namespace HSCFiscalRegistrar.DTO.RequestForOFD.ZXReport
{
    public class Section
    {
        public string SectionCode { get; set; }
        public List<OperationZX> Operations { get; set; }
    }
}