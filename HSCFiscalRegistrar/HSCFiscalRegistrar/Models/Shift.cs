using HSCFiscalRegistrar.DTO.DateAndTime;
using HSCFiscalRegistrar.Models.APKInfo;

namespace HSCFiscalRegistrar.Models
{
    public class Shift
    {
        public string Id { get; set; }
        public int Number { get; set; }
        public decimal TotalAmount { get; set; }
        public int OperationsCount { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public int KkmId { get; set; }
        public virtual Kkm Kkm { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}