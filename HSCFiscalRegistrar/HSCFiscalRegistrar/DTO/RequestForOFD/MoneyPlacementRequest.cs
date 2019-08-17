using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.RequestForOFD
{
    public class MoneyPlacementRequest
    {
        public Models.DateTime.DateTime DateTime { get; set; }
        public MoneyPlacementEnum Operation { get; set; }
        public Money Sum { get; set; }
        public bool IsOffline { get; set; }
        public int FrShiftNumber { get; set; }
        
    }
}