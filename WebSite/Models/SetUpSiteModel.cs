using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Template.Models
{
    public class SetUpSiteModel
    {
        [DisplayName("Administrator Email")]
        [Required(ErrorMessage = "Password required")]
        public string AdminUsername { get; set; }

        [DisplayName("Password")]
        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        public string AdminPassword { get; set; }

        [DisplayName("Confirm Password")]
        [Required(ErrorMessage = "Confirm Password required")]
        [DataType(DataType.Password)]
        public string ConfirmAdminPassword { get; set; }


    }
}