using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Template.Models.Account
{
	public class UserManagementModel
	{

		public IList<UserModel> users { get; set; }


		public UserManagementModel()
		{
			users = new List<UserModel>();
		}

	}
}