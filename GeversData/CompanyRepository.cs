using GeversLogic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeversData
{
    public class CompanyRepository : Repository
    {
        public CompanyRepository(string server, string database, string userId, string password)
          : base(server, database, userId, password)
        {

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

                while (reader.Read())
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

        public List<CarDTO> GetCars()
        {
            MySqlConnection conn = this.GetDatabaseConnection(true);
            try
            {
                List<CarDTO> cars = new List<CarDTO>();

                string sql = "SELECT * FROM cars";

                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CarDTO car = new CarDTO();
                    car.Model = Convert.ToString(reader["model"]);
                    car.Brand = Convert.ToString(reader["brand"]);

                    cars.Add(car);
                }
                return cars;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
