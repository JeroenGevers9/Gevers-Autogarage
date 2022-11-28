using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeversLogic
{
	public class User
	{
		public User()
		{
			//this.Username = user.Username;
			//this.EmployeeId = user.EmployeeId;
		}

		//public bool CheckExist(string userName, string passWord)
		//{
		//	UserRepository userRepo = new UserRepository(_server, _database, _userId, _password);
		//	if(userRepo.CheckExist(userName, passWord))
		//	{
		//		return true;
		//	}
		//	return false;
		//}

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
