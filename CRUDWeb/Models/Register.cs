using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Register
    {
        [Required(ErrorMessage ="Email Address is Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is Required")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password didn't match!")]
        public string ConfirmPassword { get; set; }
        public string RoleName { get; set; }
    }
}
