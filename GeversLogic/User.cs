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
		public string Password { get; private set; }
		public Employee Employee { get; set; }
		public User(IUserStorage _userStorage)
		{
			_UserStorage = _userStorage;
		}

		public bool CheckExist(string userName, string passWord)
		{
			if(_UserStorage.CheckExist(userName, passWord))
			{
				return true;
			}
			return false;
		}

		public bool isEmployee()
		{
			if (this.Employee != null)
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
