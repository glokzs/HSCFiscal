using HSCFiscalRegistrar.DTO.XReport.OfdResponse;
using HSCFiscalRegistrar.Enums;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.DTO.CloseShift.OfdResponse
{
    public class Report
    {
        [JsonProperty("zx_report")]
        public ZXReport ZxReport { get; set; }
        [JsonProperty("report")]
        public ReportTypeEnum ReportType { get; set; }
    }
}