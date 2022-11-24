using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeversData
{
    public class Repository
    {
        private string ConnectionString;

        public Repository(string server, string database, string userId, string password)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = server;
            builder.Database = database;
            builder.UserID = userId;
            builder.Password = password;

            ConnectionString = builder.ToString();
        }

        protected MySqlConnection GetDatabaseConnection(bool openConnection = false)
        {
            MySqlConnection connection = new MySqlConnection(ConnectionString);
            if (openConnection)
            {
                connection.Open();
            }
            return connection;
        }
    }
}
