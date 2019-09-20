using HSCFiscalRegistrar.DTO.DateAndTime;

namespace HSCFiscalRegistrar.Models
{
    public class Shift
    {
        public string Id { get; set; }
        public int Number { get; set; }
        public decimal TotalSum { get; set; }
        public int TotalCount { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public int TerminalReqNum { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}