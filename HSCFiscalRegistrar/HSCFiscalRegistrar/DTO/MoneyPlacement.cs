using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO
{
    public class MoneyPlacement
    {
        public bool IsOffline { get; set; }
        public MoneyPlacementEnum Operation { get; set; }
        public Models.DateTime.DateTime DateTime { get; set; }
        public Money Sum { get; set; }
    }
}