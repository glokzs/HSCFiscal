using HSCFiscalRegistrar.Models.ResponseInKkm;

namespace HSCFiscalRegistrar.Models
{
    public class CheckOperation : Data
    {
        public int CheckOrderNumber { get; set; }
        public int ShiftNumber { get; set; }
        public string EmployeeName { get; set; }
        public string TicketUrl { get; set; }
    }
}