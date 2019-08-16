namespace HSCFiscalRegistrar.Enums
{
    public enum ResultTypeEnum
    {
        ResultTypeOk = 0,
        ResultTypeUnknownId = 1,
        ResultTypeInvalidToken = 2,
        ResultTypeProtocolError = 3,
        ResultTypeUnknownCommand = 4,
        ResultTypeUnsupportedCommand = 5,
        ResultTypeInvalidConfiguration = 6,
        ResultTypeSslIsNotAllowed = 7,
        ResultTypeInvalidRequestNumber = 8,
        ResultTypeInvalidRetryRequest = 9,
        ResultTypeCantCancelTicket = 10,
        ResultTypeOpenShiftTimeoutExpired = 11,
        ResultTypeInvalidLoginPassword = 12,
        ResultTypeIncorrectRequestData = 13,
        ResultTypeNotEnoughCash = 14,
        ResultTypeBlocked = 15,
        ResultTypeServiceTemporarilyUnavailable = 254,
        ResultTypeUnknownError = 255
    }
}