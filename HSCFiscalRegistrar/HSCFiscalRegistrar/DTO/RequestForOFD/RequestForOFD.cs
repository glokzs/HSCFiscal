using HSCFiscalRegistrar.DTO.RequestForOFD.CheckProcessing;
using HSCFiscalRegistrar.DTO.RequestForOFD.FinanceOperations;
using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.RequestForOFD
{
    public class RequestForOFD
    {
        public OperationTypeEnum Operation { get; set; }
        public TicketRequest TicketRequest { get; set; }
        public CloseShiftRequest CloseShift { get; set; }
        public ReportRequest Report { get; set; }
        public NomenclatureRequest Nomenclature { get; set; }
        public ServiceRequest Service { get; set; }
        public MoneyPlacementRequest MoneyPlacement { get; set; }
        public AuthRequest Auth { get; set; }
    }
}