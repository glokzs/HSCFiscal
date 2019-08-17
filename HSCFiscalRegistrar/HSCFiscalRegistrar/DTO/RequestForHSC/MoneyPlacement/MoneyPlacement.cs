using HSCFiscalRegistrar.DTO.DateAndTime;
using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO.RequestForHSC.MoneyPlacement
{
    public class MoneyPlacement
    {
        public bool IsOffline { get; set; }
        public MoneyPlacementEnum Operation { get; set; }
        public DateTime DateTime { get; set; }
        public Money Sum { get; set; }
    }
}