using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gevers_Autogarage.Classes
{
    public class DbClass
    {
        private static MySqlConnection conn;
        private static MySqlCommand command;
        private static DataTable dt;
        private static MySqlDataAdapter sda;


        public static MySqlConnection EstablishConnection()
        {
            try
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = "127.0.0.1";
                builder.UserID = "root";
                //builder.Password = "Lekkeretaart";
                builder.Password = "";
                builder.Database = "garage-gevers";
                conn = new MySqlConnection(builder.ToString());
                return conn;
            }
            catch (Exception)
            {
                return new MySqlConnection();
            }
        }

        public static string Login(string userName, string passWord)
        {
            conn.Open();
            string loginSuccessful = "";

            string sql = "SELECT * FROM users WHERE username='" + userName + "'AND password='" + passWord + "'";

            MySqlCommand sqlCommand = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = sqlCommand.ExecuteReader();

            if (rdr.HasRows)
            {
                
                loginSuccessful = rdr.ToString();
            }
            conn.Close();
            return loginSuccessful;
        }

    }
}
