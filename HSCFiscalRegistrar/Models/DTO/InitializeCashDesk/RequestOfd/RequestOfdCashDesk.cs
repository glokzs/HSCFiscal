namespace Models.DTO.InitializeCashDesk.RequestOfd
{
    public class RequestOfdCashDesk
    {
        public int DeviceId { get; set; }
        public string FnsKkmId { get; set; }
        public int TokenOfd { get; set; }
        public string SerialNumber { get; set; }
        public string NameOrg { get; set; }
        public string Iin { get; set; }
        public int ReqNum { get; set; }
    }
}