using System;
using System.ComponentModel.DataAnnotations;
using Models.DTO.XReport.OfdResponse;
using Newtonsoft.Json;

namespace Models
{
    public class Kkm
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SerialNumber { get; set; }
        public string PointOfPayment { get; set; }
        public string FnsKkmId { get; set; }
        public string TerminalNumber { get; set; }
        public int DeviceId { get; set; }
        public int OfdToken { get; set; }
        public int ReqNum { get; set; }
        public string Address { get; set; }
        public string Iin { get; set; }
        public string NameOrg { get; set; }
        public string CurrentStatus { get; set; }
        public DateTime LastDateOperation { get; set; }
        public string Mode { get; set; }
        public string OperatorId { get; set; }
        public string UserId { get; set; }
        public string IdentificationNumber { get; set; }
        public virtual User User { get; set; }

        public Kkm()
        {
            LastDateOperation = DateTime.Now;
        }
    }
}