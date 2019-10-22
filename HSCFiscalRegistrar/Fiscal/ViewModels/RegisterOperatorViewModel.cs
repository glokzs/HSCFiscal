using Fiscal.Models.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Fiscal.ViewModels
{
    public class RegisterOperatorViewModel
    {
        [Required(ErrorMessage = "Это поле обязательно!")]
        [Display(Name = "ФИО")]
        public string Name { get; set; }
        
        public string OwnerId { get; set; }
        public string KKMId { get; set; }

        [Required(ErrorMessage = "Это поле обязательно!")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Это поле обязательно!")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
        [Trimer]
        [Required(ErrorMessage = "Это поле обязательно!")]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}