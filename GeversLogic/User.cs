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
		IUserStorage _UserStorage;
		public int Id { get; set; }
		public string Username { get; set; }
		public string Password { get; }
		public int EmployeeNr { get; set; }
		public Employee Employee { get; set; }
		public User(IUserStorage _userStorage)
		{
			_UserStorage = _userStorage;
		}

		public User CheckExist(string userName, string passWord)
		{
			return _UserStorage.CheckExist(userName, passWord);
		}

		public bool isEmployee()
		{
			if (this.Employee != null)
			{
				return true;
			}
			if(this.EmployeeNr != 0)
			{
				return true;
			}
			return false;
		}

		public void setId(int id)
		{
			this.Id = id;
		}
	}
}
