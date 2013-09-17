using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Template.Models
{

    public class LoginViewModel
    {
        [DisplayName("Email Address")]
        [Required(ErrorMessage = "Email address required")]
        public string Email { get; set; }
        
        [DisplayName("Password")]
        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}