using System;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.UserModels
{
    public class RegisterModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Time")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? DateOfCreating { get; set; } = DateTime.Now;

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}