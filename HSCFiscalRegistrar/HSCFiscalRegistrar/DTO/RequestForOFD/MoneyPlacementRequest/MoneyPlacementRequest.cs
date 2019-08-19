using HSCFiscalRegistrar.DTO.DateAndTime;
using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.RequestForOFD.MoneyPlacementRequest
{
    public class MoneyPlacementRequest : Finance.Finance
    {
        public DateTime DateTime { get; set; }
        public MoneyPlacementEnum Operation { get; set; }
        public bool IsOffline { get; set; }
        public int FrShiftNumber { get; set; }
        
    }
}