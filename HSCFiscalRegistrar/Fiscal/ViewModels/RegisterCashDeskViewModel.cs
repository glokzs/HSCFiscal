using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Fiscal.ViewModels
{
    public class RegisterCashDeskViewModel
    {
        [Required]
        [Display(Name = "Name")]
        [Remote("CheckName", "Initialization", ErrorMessage = "Это имя уже занято", AdditionalFields = "Id")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
    }
}