using System;
using HSCFiscalRegistrar.Enums;
using HSCFiscalRegistrar.Models;

namespace HSCFiscalRegistrar.RequestModels
{
    public abstract class MoneyPlacementRequest
    {
        public DateTime DateTime { get; set; }
        public MoneyPlacementEnum Operation { get; set; }
        public Money Sum { get; set; }
        public bool IsOffline { get; set; }
        public int FrShiftNumber { get; set; }
    }
}