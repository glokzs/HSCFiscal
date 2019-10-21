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
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
        
        [Required]
        [Display(Name= "Старый пароль")]
        public string OldPassword { get; set; }
        
    }
}