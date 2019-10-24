using System;

namespace Models.DTO.Fiscalization.KKMResponce
{
    public class Data
    {
        public string CheckNumber { get; set; }
        public string DateTime { get; set; }
        public bool OfflineMode { get; set; }
        public bool CashboxOfflineMode { get; set; }
        public Cashbox Cashbox { get; set; }
        public int CheckOrderNumber { get; set; }
        public int ShiftNumber { get; set; }
        public string EmployeeName { get; set; }
        public string TicketUrl { get; set; }
    }
}