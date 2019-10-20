using Models.DTO.DateAndTime;
using Models.Enums;
using DateTime = Models.DTO.DateAndTime.DateTime;

namespace Models.DTO.CloseShift
{
    public class CloseShiftRequest
    {
        public CommandTypeEnum Command { get; set; }
        public int DeviceId { get; set; }
        public int ReqNum { get; set; }
        public int Token { get; set; }
        public CloseShift CloseShift { get; set; }
        public Service Service { get; set; }

        public CloseShiftRequest(Kkm kkm, User org, int shiftNumber)
        {
            Command = CommandTypeEnum.COMMAND_CLOSE_SHIFT;
            Service = new Service(new RegInfo(org, kkm));
            DeviceId = kkm.DeviceId;
            ReqNum = kkm.ReqNum;
            Token = kkm.OfdToken;
            CloseShift = new CloseShift
            {
                IsOffline = false,
                FrShiftNumber = shiftNumber,
                DateTime = new DateTime
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
                }
            };
        }
    }
}