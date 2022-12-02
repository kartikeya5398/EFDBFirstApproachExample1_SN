using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EFDBFirstApproachExample1.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "UserName can't Blank")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password can't Blank")]
        public string Password { get; set; }
    }
}