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
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public string KkmId { get; set; }
        public virtual Kkm Kkm { get; set; }

        public Operation( OperationTypeEnum type, string shiftId,
            OperationStateEnum operationState,
            DateTime creationDate, decimal amount, decimal changeAmount, decimal cashAmount,
            decimal cardAmount, string userId, string kkmId, User user, Kkm kkm, int checkNumber)
        {
            CheckNumber = checkNumber;
            Kkm = kkm;
            User = user;
            Type = type;
            ShiftId = shiftId;
            OperationState = operationState;
            IsOffline = false;
            CreationDate = creationDate;
            Amount = amount;
            ChangeAmount = changeAmount;
            CashAmount = cashAmount;
            CardAmount = cardAmount;
            UserId = userId;
            KkmId = kkmId;
        }

        public Operation()
        {
        }
    }
}