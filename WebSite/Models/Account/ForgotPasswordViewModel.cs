using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Template.Models.Account
{
	public class ForgotPasswordViewModel
	{
		[DisplayName("Enter your Email Address")]
		[Required(ErrorMessage = "Email address required")]
		public string Email { get; set; }
	}
}