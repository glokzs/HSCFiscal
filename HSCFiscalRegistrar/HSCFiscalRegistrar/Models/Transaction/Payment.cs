using HSCFiscalRegistrar.Enums;

namespace HSCFiscalRegistrar.Models.Transaction
{
    public class Payment
    {
        public string Id { get; set; }
        public decimal Sum { get; set; }
        public PaymentTypeEnum PaymentType { get; set; }
        public int ShiftNumber { get; set; }
        public bool Status { get; set; }
        public int OperationNumber { get; set; }
    }
}