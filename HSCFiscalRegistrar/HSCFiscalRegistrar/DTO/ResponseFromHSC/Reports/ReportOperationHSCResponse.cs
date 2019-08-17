using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.ResponseFromHSC.Reports
{
    public class ReportOperationHSCResponse : DataHSCResponse
    {
        public Report Report { get; set; }
        public CommandTypeEnum CommandEnum { get; set; }
        public int Token { get; set; }
    }
}