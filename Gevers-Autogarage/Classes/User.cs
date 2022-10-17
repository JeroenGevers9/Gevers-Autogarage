using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gevers_Autogarage.Classes
{
    public class User
    {
		public string Username
		{
			get;
			private set;
		}
	
		private string password;

		public string Password
		{
			get;
			private set;
		}

		private bool isEmployee;

		public bool IsEmployee
		{
			get;
			private set;
		}


		public User(string userName)
		{
			this.Username = userName;
		}
	}
}
