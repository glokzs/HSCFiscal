using System.ComponentModel.DataAnnotations;

namespace Fiscal.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Почтовой адрес")]
        public string Email { get; set; }
         
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
         
        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }
         
        public string ReturnUrl { get; set; }
    }
}