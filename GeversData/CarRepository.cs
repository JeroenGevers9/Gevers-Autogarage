using GeversLogic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeversData
{
    public class CarRepository : Repository, ICarStorage
    {
        public CarRepository(string server, string database, string userId, string password)
                   : base(server, database, userId, password)
        {

        }


        public List<Accessoire> GetAccessoires()
        {
            MySqlConnection conn = this.GetDatabaseConnection(true);
            try
            {
                List<Accessoire> accessoires = new List<Accessoire>();

                string sql = "SELECT * FROM accessoires";

                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Accessoire accessoire = new Accessoire();
                    accessoire.Name = Convert.ToString(reader["name"]);
                    accessoire.Price = Convert.ToDecimal(reader["price"]);

                    accessoires.Add(accessoire);
                }
                return accessoires;
            }
            finally
            {
                conn.Close();
            }
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
            finally
            {
                conn.Close();
            }
        }

        public Car Read(string brand, string model, string constructionYear)
        {

            MySqlConnection conn = this.GetDatabaseConnection(true);
            try
            {
                //string sql = "DELETE FROM cars WHERE brand = @brand AND WHERE model = @model AND WHERE construction_year = @constructionYear";
                string sql = "SELECT * FROM cars WHERE brand = @brand AND WHERE model = @model AND WHERE construction_year = @constructionYear";

                MySqlCommand command = new MySqlCommand(sql, conn);
                command.ExecuteNonQuery();

                command.Parameters.AddWithValue("@brand", brand);
                command.Parameters.AddWithValue("@model", model);
                command.Parameters.AddWithValue("@constructionYear", constructionYear);
                command.ExecuteNonQuery();

                MySqlDataReader reader = command.ExecuteReader();
                Car car = new Car();

                if(reader.Read())
                {
                    car.Brand= Convert.ToString(reader["brand"]);
                    car.Model = Convert.ToString(reader["model"]);
                    car.ConstructionYear= Convert.ToInt32(reader["construction_year"]);
                }
                return car;
            }
            finally
            {
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
