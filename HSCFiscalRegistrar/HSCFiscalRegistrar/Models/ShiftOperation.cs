using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.Models
{
    public class ShiftOperation
    {
        public OperationTypeEnum OperationType { get; set; }
        public decimal Amount { get; set; }
        public decimal Count { get; set; }
        public decimal Cash { get; set; }
        public decimal Card { get; set; }
        public string ShiftId { get; set; }
        public Shift Shift { get; set; }
    }
}