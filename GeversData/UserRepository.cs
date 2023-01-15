using GeversLogic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeversData
{
    public class UserRepository : Repository, IUserStorage
    {

        public UserRepository(string server, string database, string userId, string password)
            : base(server, database, userId, password)
        {

        }

        public User CheckExist(string userName, string passWord)
        {
            MySqlConnection conn = this.GetDatabaseConnection(true);
            try
            {
                string sql = "SELECT * FROM users WHERE username='" + userName + "'AND password='" + passWord + "'";

                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                User user = new User(this);

                while (reader.Read())
                {
                    user.Id = Convert.ToInt32(reader["id"]);
                    user.EmployeeNr = Convert.ToInt32(reader["employee_id"]);
                    user.Username = Convert.ToString(reader["username"]);
                }

                if(user.EmployeeNr != 0)
                {
                    user.Employee = this.getEmployee(user);
                }

                return user;
            }
            finally
            {
                conn.Close();
            }
        }

        private Employee getEmployee(User user)
        {
            MySqlConnection conn = this.GetDatabaseConnection(true);
            try
            {
                string sql = "SELECT * FROM employees WHERE employee_nr='" + user.EmployeeNr + "'";

                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                Employee employee = new Employee(this, user);

                while (reader.Read())
                {
                    employee.Function = Convert.ToInt32(reader["function"]);
                }
                return employee;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
