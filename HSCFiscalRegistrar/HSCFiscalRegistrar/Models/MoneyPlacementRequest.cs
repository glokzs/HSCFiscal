using System;
using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.Models
{
    public class MoneyPlacementRequest
    {
        public DateTime DateTime { get; set; }
        public MoneyPlacementEnum Operation { get; set; }
        public Money Sum { get; set; }
        public bool IsOffline { get; set; }
        public int FrShiftNumber { get; set; }
    }
    
}