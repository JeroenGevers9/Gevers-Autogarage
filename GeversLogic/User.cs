using GeversData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeversLogic
{
    public class User
	{
		public User(UserDTO user)
		{
			this.Username = user.Username;
			this.EmployeeId = user.EmployeeId;
		}

		public string Username { get; set; }
		public string Password { get; private set; }
		public int EmployeeId { get; set; }

		public bool isEmployee()
		{
			if (this.EmployeeId != 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
