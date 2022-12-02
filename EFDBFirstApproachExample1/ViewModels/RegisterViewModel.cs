using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFDBFirstApproachExample1.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage="UserName can't Blank")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password can't Blank")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword can't Blank")]
        [Compare("Password", ErrorMessage ="Password do not match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage ="Email can't Blank")]
        [EmailAddress(ErrorMessage ="Invalid Email")]
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}