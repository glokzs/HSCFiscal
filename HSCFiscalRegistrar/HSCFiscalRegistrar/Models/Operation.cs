using System;
using HSCFiscalRegistrar.Enums;
using HSCFiscalRegistrar.Models.APKInfo;
using DateTime = System.DateTime;

namespace HSCFiscalRegistrar.Models.Operation
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
        public int FiscalNumber { get; set; }
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