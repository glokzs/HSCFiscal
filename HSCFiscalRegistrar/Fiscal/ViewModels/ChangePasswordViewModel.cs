

using System.ComponentModel.DataAnnotations;

namespace Fiscal.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        
        [Required]
        [Display(Name= "Новый пароль")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        
        [Required]
        [Display(Name= "Повторите пароль")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Пароли не совпадают!")]
        public string PasswordConfirm { get; set; }
    }
}