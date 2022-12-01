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
    }
}
