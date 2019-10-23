using System.ComponentModel.DataAnnotations;
using Fiscal.Models.Attributes;
using Microsoft.AspNetCore.Mvc;
using Models.Enums;

namespace Fiscal.ViewModels
{
    public class RegisterMerchViewModel
    {
        [Trimer]
        [EmailAddress]
        [Required(ErrorMessage = "Это поле обязательно!")]
        [Display(Name = "Email")]
        [Remote("CheckEmail", "Account", ErrorMessage = "Эта почта уже зарегистрирована", AdditionalFields = "Id")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Это поле обязательно!")]
        [Display(Name = "ФИО")]
        public string FIO { get; set; }
        
        [Phone(ErrorMessage = "Введите корректный номер телефона")]
        [Required(ErrorMessage = "Это поле обязательно!")]
        [Display(Name = "Номер телефона")]
        public string PhoneNumberUser { get; set; }
        
        [MaxLength(12, ErrorMessage = "Длина ИИН должна составлять 12 цифр")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Длина ИИН должна составлять 12 цифр")]
        [Required(ErrorMessage = "Это поле обязательно!")]
        [Display(Name = "ИИН")]
        [Remote("CheckIin", "Account", ErrorMessage = "Этот иин уже зарегистрирован", AdditionalFields = "Id")]
        public string IIN { get; set; }
        
        [Required(ErrorMessage = "Это поле обязательно!")]
        [Display(Name = "Наименование компании")]
        [Remote("CheckTitle", "Account", ErrorMessage = "Это название уже занято", AdditionalFields = "Id")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Это поле обязательно!")]
        [Display(Name = "Юридический адрес")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Это поле обязательно!")]
        [Display(Name = "Налоговый режим")]
        public TaxationTypeEnum TaxationType { get; set; }
        
        [Display(Name = "Плательщик НДС")]
        public bool VAT { get; set; }
        
        [Display(Name = "Серия НДС")]
        public string VATSeria { get; set; }
        
        [Display(Name = "Номер НДС")]
        public string VATNumber { get; set; }

        [Required(ErrorMessage = "Это поле обязательно!")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        
 
        [Required(ErrorMessage = "Это поле обязательно!")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
        
        public override string ToString()
        {
            return $"{Email}:{Password}";
        }
    }
}