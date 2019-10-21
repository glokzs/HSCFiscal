using Models.DTO.DateAndTime;
using Models.DTO.RequestOfd;
using Models.DTO.RequestOperatorOfd;
using Models.Enums;

namespace Models.DTO.XReport.OfdRequest
{
    public class XReportOfdRequestModel
    {
        public CommandTypeEnum Command { get; set; }
        public int DeviceId { get; set; }
        public int ReqNum { get; set; }
        public int Token { get; set; }
        public Service Service { get; set; }
        public Report Report { get; set; }

        public XReportOfdRequestModel(Kkm kkm, User user)
        {
            Command = CommandTypeEnum.COMMAND_REPORT;
            DeviceId = kkm.DeviceId;
            ReqNum = kkm.ReqNum;
            Token = kkm.OfdToken;
            var regInfo = new RegInfo(GetOrg(user), GetKkm(kkm));
            Service = new Service(regInfo);
            Report = new Report(ReportTypeEnum.REPORT_X, GetDateTime(), false);
        }

        private OfdKkm GetKkm(Kkm kkm)
        {
            return new OfdKkm
            {
                FnsKkmId = kkm.FnsKkmId,
                PointOfPaymentNumber = kkm.PointOfPayment,
                SerialNumber = kkm.SerialNumber,
                TerminalNumber = kkm.TerminalNumber
            };
        }
        
        private Org GetOrg(User user)
        {
            return new Org
            {
                Inn = user.Inn,
                Okved = user.Okved,
                TaxationType = user.TaxationType,
                Title = user.Title
            };
        }
        private DateTime GetDateTime()
        {
            return new DateTime
            {
                Date = new Date
                {
                    Day = System.DateTime.Now.Day,
                    Month = System.DateTime.Now.Month,
                    Year = System.DateTime.Now.Year
                },
                Time = new Time
                {
                    Hour = System.DateTime.Now.Hour,
                    Minute = System.DateTime.Now.Minute,
                    Second = System.DateTime.Now.Second
                }
            };
        }
    }
}