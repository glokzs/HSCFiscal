using System.Collections.Generic;
using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.XReport.OfdResponse
{
    public class Tax
    {
        public TaxTypeEnum Type { get; set; }
        public int Percent { get; set; }
        public List<TaxOperation> Operations { get; set; }
    }
}