using Models.APKInfo;
using Models.Enums;
using DateTime = System.DateTime;

namespace Models
{
    public class Operation
    {
        public string Id { get; set; }
        public OperationTypeEnum Type { get; set; }
        public string ShiftId { get; set; }
        public virtual Shift Shift { get; set; }
        public OperationStateEnum OperationState { get; set; }
        public bool IsOffline { get; set; }
        public int CheckNumber { get; set; }
        public string FiscalNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public string QR { get; set; }
        public decimal Amount { get; set; }
        public decimal ChangeAmount { get; set; }
        public decimal CashAmount { get; set; }
        public decimal CardAmount { get; set; }
        public decimal CashAmountFromClient { get; set; }
        public string OperatorId { get; set; }
        public virtual Operator Operator { get; set; }
        public string KkmId { get; set; }
        public virtual Kkm Kkm { get; set; }
    }
}