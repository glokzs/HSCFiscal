using HSCFiscalRegistrar.DTO.Fiscalization.OFD;
using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.Models.Transaction
{
    public class Transaction
    {
        public string Id { get; set; }
        public string CashboxUniqueNumber { get; set; }
        public OperationTypeEnum OperationType { get; set; }
        public string PaymentsId { get; set; }
        public virtual Payment Payment { get; set; }
        public StateOfTransactionEnum State { get; set; }
        public int CheckNumber { get; set; }
        public int ShiftNumber { get; set; }
        public string TiketUrl { get; set; }
    }

    
}