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
                builder.Database = "fietsenverhuur";
                conn = new MySqlConnection(builder.ToString());
                return conn;
            }
            catch (Exception)
            {
                return new MySqlConnection();
            }
        }

        public static bool Login(string userName, string passWord)
        {
            conn.Open();
            bool loginSuccessful = false;

            string sql = "SELECT* FROM medewerker WHERE voornaam='" + userName + "'AND datum_in_dienst='" + passWord + "'";

            MySqlCommand sqlCommand = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = sqlCommand.ExecuteReader();

            if (rdr.HasRows)
            {
                loginSuccessful = true;
            }
            conn.Close();
            return loginSuccessful;
        }

    }
}
