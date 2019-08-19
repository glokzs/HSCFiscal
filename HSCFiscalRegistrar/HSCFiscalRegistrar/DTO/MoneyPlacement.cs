using HSCFiscalRegistrar.DTO.DateAndTime;
using HSCFiscalRegistrar.DTO.RequestForOFD.Finance;
using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.DTO
{
    public class MoneyPlacement : Finance
    {
        public bool IsOffline { get; set; }
        public MoneyPlacementEnum Operation { get; set; }
        public DateTime DateTime { get; set; }
    }
}