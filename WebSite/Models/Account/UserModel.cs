using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Template.Models.Account
{
	public class UserModel
	{

		public string Username { get; set; }
		public string Email { get; set; }

		public IList<RolesModel> Roles { get; set; }

		public UserModel()
		{
			Roles = new List<RolesModel>();
		}


	}
}