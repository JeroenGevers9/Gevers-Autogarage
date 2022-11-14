﻿using GeversData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeversLogic
{
    public class User
	{
		public static User Login(string userName, string passWord)
		{
			UserDTO userDTO = Repository.Login(userName, passWord);

			User user = new User(userDTO.Username, userDTO.EmployeeId);

			return user;
		}

		public User(string UserName, int employeeId)
		{
			this.Username = UserName;
			this.EmployeeId = employeeId;
		}

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