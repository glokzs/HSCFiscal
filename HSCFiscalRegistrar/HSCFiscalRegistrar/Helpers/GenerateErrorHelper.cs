using System.Collections.Generic;
using System.Linq;
using Models.DTO.ErrorsDTO;
using Newtonsoft.Json;

namespace HSCFiscalRegistrar.Helpers
{
    public class GenerateErrorHelper
    {
        private Dictionary<int, string> _dictionary = new Dictionary<int, string>();

        public GenerateErrorHelper() => CreateDictionary();

        private void CreateDictionary()
        {
            _dictionary.Add(-1, "Неизвестная ошибка");
            _dictionary.Add(1, "Неверный логин или пароль");
            _dictionary.Add(2, "Срок действия сессии истек");
            _dictionary.Add(3, "Пользователь не авторизован");
            _dictionary.Add(4, "Нет доступа к операции");
            _dictionary.Add(5, "Нет доступа к кассе");
            _dictionary.Add(6, "Касса не найдена");
            _dictionary.Add(7, "Касса заблокирована ");
            _dictionary.Add(8, "Недостаточно суммы для изъятия");
            _dictionary.Add(9, "Ошибка валидации данных");
            _dictionary.Add(10, "Касса не активирована");
            _dictionary.Add(11,
                "Продолжительность смены превышает 24 часа. Для продолжения работы необходимо закрыть смену.");
            _dictionary.Add(12, "Смена уже закрыта");
            _dictionary.Add(13, "Не найдена открытая смена");
            _dictionary.Add(14, "Дублирующийся код системы источника ");
            _dictionary.Add(15, "Смена не найдена");
            _dictionary.Add(16, "Чек № <NNN> не зарегистрирован в рамках <NN> смены в MBK000000000 Кассе");
            _dictionary.Add(18,
                "Продолжительность работы в автономном режиме превышает 72 часа. Для продолжения работы с кассой необходимо подклюение к ОФД");
            _dictionary.Add(1014, "Данная смена открыта. Z-отчет отсутствует ");
        }

        public string GetErrorRequest(int key)
        {
            KeyValuePair<int, string> error = _dictionary.FirstOrDefault(p => p.Key == key);
            
            ErrorsWrapper errors = new ErrorsWrapper
            {
                Errors   = new []
                {
                    new Error
                    {
                        Code = error.Key,
                        Text = error.Value
                    } 
                }
            };

            return JsonConvert.SerializeObject(error);
        }
        
    }
}