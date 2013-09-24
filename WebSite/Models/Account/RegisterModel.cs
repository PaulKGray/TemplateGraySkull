using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Template.Models.Account
{
    public class RegisterModel
    {
        public LoginViewModel UserDetails { get; set; }

        [DisplayName("Your Name")]
        [Required(ErrorMessage = "We need your name")]
        public string Name { get; set; }

        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "Confirm Password required")]
        [DataType(DataType.Password)]
        public string ConfirmAdminPassword { get; set; }
    }
}