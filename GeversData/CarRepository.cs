using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeversData
{
    public class CarRepository : Repository
    {
        public CarRepository(string server, string database, string userId, string password)
                   : base(server, database, userId, password)
        {

        }

        public bool Create(string brand, string model, decimal price, string constructionYear)
        {
            MySqlConnection conn = this.GetDatabaseConnection(true);
            try
            {
                string sql = "INSERT INTO users (brand, model, price, contruction_year) VALUES (@brand, @model, @price, @contruction_year)";
                MySqlCommand command = new MySqlCommand(sql, conn);

                command.Parameters.AddWithValue("@brand", brand);
                command.Parameters.AddWithValue("@model", model);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@construction_year", constructionYear);
                command.ExecuteNonQuery();

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) return true;
                else return false;
            }
            finally {
                conn.Close();
            }
        }

        public bool Update(string brand, string model, decimal price, string constructionYear)
        {
            MySqlConnection conn = this.GetDatabaseConnection(true);
            try
            {
                string sql = "UPDATE users (brand, model, price, contruction_year) VALUES (@brand, @model, @price, @contruction_year) WHERE id = ";
                MySqlCommand command = new MySqlCommand(sql, conn);

                command.Parameters.AddWithValue("@brand", brand);
                command.Parameters.AddWithValue("@model", model);
                command.Parameters.AddWithValue("@price", price);
                command.Parameters.AddWithValue("@construction_year", constructionYear);
                command.ExecuteNonQuery();

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) return true;
                else return false;
            }
            finally
            {
                conn.Close();
            }
        }

        public bool Delete(int id)
        {

            MySqlConnection conn = this.GetDatabaseConnection(true);
            try
            {
                string sql = "DELETE FROM land WHERE id = @id";

                MySqlCommand command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();

                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();

                MySqlDataReader reader = command.ExecuteReader();

                if (reader.Read()) return true;
                else return false;
            }
            finally
            {
                conn.Close();
            }
        }


    }
}
