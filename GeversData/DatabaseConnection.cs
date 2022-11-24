using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GeversData
{
    public static class DatabaseConnection
    {
        private static MySqlConnection conn;
        private static MySqlCommand command;
        private static DataTable dt;
        private static MySqlDataAdapter sda;

        public static bool EstablishConnection()
        {
            //string connString = @"Server=127.0.0.1;Database=garage-gevers;Integrated Security=true;";
            // string connString1 = @"Data Source=DESKTOP-COUET6S;Initial Catalog=garage-gevers;User ID=root;Password=";
            //"DESKTOP-COUET6S"

            try
            {
                //conn = new MySqlConnection(@"Data Source=localhost;Integrated Security=true;Initial Catalog=garage-gevers");

                //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                //builder.DataSource = "127.0.0.1";
                //builder.UserID = "root";
                //builder.Password = "";
                //builder.InitialCatalog = "garage-gevers";
                //conn = new MySqlConnection(builder.ToString());
                //conn.Open();

                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = "127.0.0.1";
                builder.UserID = "root";
                builder.Password = "";
                builder.Database = "garage-gevers";
                conn = new MySqlConnection(builder.ToString());
                


                return true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static MySqlConnection getConnection() { return conn; }
    }
}
