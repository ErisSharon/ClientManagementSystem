using BmatApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace BmatApplication.Models
{
    public class RegisterModel
    {
        //common properties to all users
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "passwords don't match")]
        [Display(Name = " Confirm Password")]
        public string? ConfirmPassword { get; set; }
    }
}