using System.Xml.Linq;
using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.XReport.OfdResponse
{
    public class ZXOfdResponse
    {
        public ReportTypeEnum Report { get; set; }
        public ZXReport ZXReport { get; set; }
    }
}