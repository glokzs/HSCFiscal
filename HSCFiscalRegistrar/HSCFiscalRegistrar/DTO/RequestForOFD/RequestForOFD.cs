using HSCFiscalRegistrar.DTO.RequestForOFD.CheckProcessing;
using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.RequestForOFD
{
    public class RequestForOFD
    {
        public OperationTypeEnum Operation { get; set; }
        public TicketRequest TicketRequest { get; set; }
        public CloseShiftRequest.CloseShiftRequest CloseShift { get; set; }
        public ReportRequest.ReportRequest Report { get; set; }
        public NomenclatureRequest.NomenclatureRequest Nomenclature { get; set; }
        public ServiceRequest.ServiceRequest Service { get; set; }
        public MoneyPlacementRequest.MoneyPlacementRequest MoneyPlacement { get; set; }
        public AuthRequest Auth { get; set; }
    }
}