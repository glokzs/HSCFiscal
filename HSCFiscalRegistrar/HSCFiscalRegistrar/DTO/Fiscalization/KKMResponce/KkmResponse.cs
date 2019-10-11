using HSCFiscalRegistrar.Models;
using HSCFiscalRegistrar.Models.Operation;

namespace HSCFiscalRegistrar.DTO.Fiscalization
{
    public class KkmResponse
    {
        public Data Data { get; set; }

        public KkmResponse(Operation operation, Shift shift)
        {
            Data = new Data
            {
                DateTime = operation.CreationDate,
                CheckNumber = operation.CheckNumber.ToString(),
                OfflineMode = true,
                Cashbox = new Cashbox
                {
                    Address = operation.Kkm.Address,
                    IdentityNumber = operation.Kkm.DeviceId.ToString(),
                    UniqueNumber = operation.Kkm.SerialNumber,
                    RegistrationNumber = operation.Kkm.FnsKkmId
                },
                CashboxOfflineMode = true,
                CheckOrderNumber = operation.Kkm.ReqNum,
                ShiftNumber = shift.Number,
                EmployeeName = operation.Operator.Name,
                TicketUrl = operation.QR,
            };
        }
    }
}