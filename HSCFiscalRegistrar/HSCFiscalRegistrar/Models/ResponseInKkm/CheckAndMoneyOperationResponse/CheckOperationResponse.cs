namespace HSCFiscalRegistrar.Models.ResponseInKkm.CheckAndMoneyOperationResponse
{
    public class CheckOperation : DataResponse
    {
        public int CheckOrderNumber { get; set; }
        public int ShiftNumber { get; set; }
        public string EmployeeName { get; set; }
        public string TicketUrl { get; set; }
    }
}