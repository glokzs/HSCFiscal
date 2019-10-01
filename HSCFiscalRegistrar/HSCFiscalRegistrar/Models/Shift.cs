using HSCFiscalRegistrar.DTO.DateAndTime;
using HSCFiscalRegistrar.DTO.Fiscalization.OFD;
using HSCFiscalRegistrar.Models.APKInfo;

namespace HSCFiscalRegistrar.Models
{
    public class Shift
    {
        public string Id { get; set; }
        public int Number { get; set; }
        public System.DateTime OpenDate { get; set; }
        public System.DateTime CloseDate { get; set; }
        public int KkmId { get; set; }
        public virtual Kkm Kkm { get; set; }
        public string OperatorId { get; set; }
        public virtual Operator Operator{ get; set; }
        public decimal SaldoBegin { get; set; }
        public decimal SaldoEnd { get; set; }
        public decimal KkmBalance { get; set; }
    }
}