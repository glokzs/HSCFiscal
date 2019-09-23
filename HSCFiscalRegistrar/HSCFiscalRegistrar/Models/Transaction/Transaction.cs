using System;
using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.Models.Transaction
{
    public class Transaction
    {
        public string Id { get; set; }
        public string CashboxUniqueNumber { get; set; }
        public OperationTypeEnum OperationType { get; set; }
        public string PaymentId { get; set; }
        public virtual Payment Payment { get; set; }
        public StateOfTransactionEnum State { get; set; }
        public int CheckNumber { get; set; }
        public int ShiftId { get; set; }
        public virtual Shift Shifts { get; set; }
        public string TiketUrl { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ChangeDate { get; set; }
        
    }

    
}