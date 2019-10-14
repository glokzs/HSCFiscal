namespace HSCFiscalRegistrar.Enums
{
    public enum ErrorEnums
    {
        GOOD_RES = 0,
        //неизвестная ошибка
        UNKNOWN_ERROR = -1,
        //ошибка авторизации - неверный логин и пароль
        AUTHORIZATION_ERROR = 1,
        //ошибка сессии - истекло время
        SESSION_ERROR = 2,
        //неавторизованная ошибка - запрос от неавторизованного пользователя
        UNAUTHORIZED_ERROR = 3,
        //нет доступа к операции
        NO_ACCESS_TO_OPERATIONS = 4,
        //нет доступа к кассе
        NO_ACCESS_TO_CASH = 5,
        //касса не найдена
        CASHIER_NOT_FOUND = 6,
        //касса заблокирована
        CASH_LOCKED = 7,
        //недостаточно суммы для изьятия
        INSUFFICIENT_AMOUNT = 8,
        //ошибка валидации данных
        DATA_VALIDATION_ERROR = 9,
        //ошибка валидации данных
        CASHIER_NOT_ACTIVATED = 10,
        //ошибка валидации данных
        SHIFT_ACTIVE_24_HOURS = 11,
        //ошибка валидации данных
        SHIFT_CLOSED = 12,
        //ошибка валидации данных
        OPEN_SHIFT_NOT_FOUND = 13,
        //ошибка валидации данных
        DUPLICATE_CODE = 14,
        //ошибка валидации данных
        SHIFT_NOT_FOUND = 15,
        //ошибка валидации данных
        CHECK_NOT_REGISTERED = 16,
        //ошибка валидации данных
        OFFLINE_MODE_EXCEEDS_24_HOURS = 18,
        //ошибка валидации данных
        Z_REPORT_MISSING = 1014,
        
    }
}