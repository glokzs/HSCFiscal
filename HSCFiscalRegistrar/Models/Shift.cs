using Models.APKInfo;
using DateTime = System.DateTime;

namespace Models
{
    public class Shift
    {
        public string Id { get; set; }
        public int Number { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public string KkmId { get; set; }
        public virtual Kkm Kkm { get; set; }
        public string OperatorId { get; set; }
        public virtual Operator Operator{ get; set; }
        public decimal BuySaldoBegin { get; set; }
        public decimal SellSaldoBegin { get; set; }
        public decimal RetunSellSaldoBegin { get; set; }
        public decimal RetunBuySaldoBegin { get; set; }
        public decimal BuySaldoEnd { get; set; }
        public decimal SellSaldoEnd { get; set; }
        public decimal RetunSellSaldoEnd { get; set; }
        public decimal RetunBuySaldoEnd { get; set; }
        public decimal KkmBalance { get; set; }
    }
}