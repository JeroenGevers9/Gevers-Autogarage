using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeversData
{
    public class UserRepository : Repository
    {
        public UserRepository(string server, string database, string userId, string password)
            : base(server, database, userId, password)
        {

        }

        public bool CheckExist(string userName, string passWord)
        {
            MySqlConnection conn = this.GetDatabaseConnection(true);
            try
            {
                string sql = "SELECT * FROM users WHERE username='" + userName + "'AND password='" + passWord + "'";

                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                conn.Close();
            }
          
        }

        public List<UserDTO> GetUsers()
        {
            MySqlConnection conn = this.GetDatabaseConnection(true);
            try
            {
                List<UserDTO> users = new List<UserDTO>();

                string sql = "SELECT * FROM users";

                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while(reader.Read())
                {
                    UserDTO user = new UserDTO();
                    user.Username = Convert.ToString(reader["username"]);
                    user.EmployeeId = Convert.ToInt32(reader["employee_id"]);

                    users.Add(user);
                }
                return users;
            }
            finally
            {
                conn.Close();
            }

        }
    }
}
