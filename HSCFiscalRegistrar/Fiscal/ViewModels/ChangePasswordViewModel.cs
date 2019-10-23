

using System.ComponentModel.DataAnnotations;

namespace Fiscal.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите новый пароль")]
        [Display(Name= "Новый пароль")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        
        [Required(ErrorMessage = "Пароли должны совпадать")]
        [Display(Name= "Повторите пароль")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Пароли должны совпадать")]
        public string PasswordConfirm { get; set; }
    }
}