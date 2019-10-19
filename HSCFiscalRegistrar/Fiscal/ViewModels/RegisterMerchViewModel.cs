using System.ComponentModel.DataAnnotations;

namespace Fiscal.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Required]
        [Display(Name = "ИИН")]
        public string IIN { get; set; }
        
        [Required]
        [Display(Name = "Имя")]
        public string Title { get; set; }
        
        [Required]
        [Display(Name = "Адрес")]
        public string Adres { get; set; }

        [Required]
        [Display(Name = "Налоговый режим")]
        public string TaxationType { get; set; }
        
        [Required]
        [Display(Name = "Плательщик НДС")]
        public bool VAT { get; set; }
        
        [Required]
        [Display(Name = "Серия НДС")]
        public string VATSeria { get; set; }
        
        [Required]
        [Display(Name = "Номер НДС")]
        public string VATNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
        
 
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}