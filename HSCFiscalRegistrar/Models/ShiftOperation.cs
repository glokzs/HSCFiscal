using Models.Enums;

namespace Models
{
    public class ShiftOperation
    {
        public string Id { get; set; }
        public OperationTypeEnum OperationType { get; set; }
        public decimal TotalAmount { get; set; }
        public int Count { get; set; }
        public decimal CashAmount { get; set; }
        public decimal CardAmount { get; set; }
        public string ShiftId { get; set; }
        public virtual Shift Shift { get; set; }
        public decimal Change { get; set; }
    }
}