using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Template.Models.Account
{
	public class UserManagementModel
	{

		public IList<UserModel> users { get; set; }

        [DisplayName("Search")]
        public string SearchCriteria { get; set; }



		public UserManagementModel()
		{
			users = new List<UserModel>();
		}

	}
}