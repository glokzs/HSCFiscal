namespace Models.DTO.RequestOfd
{
    public class OfdKkm
    {
        public string SerialNumber { get; set; } = string.Empty;
        public string PointOfPaymentNumber { get; set; }
        public string FnsKkmId { get; set; }
        public string TerminalNumber { get; set; } = string.Empty;
    }
}