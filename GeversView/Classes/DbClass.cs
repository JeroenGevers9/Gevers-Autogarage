using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeversView.Classes
{
    public class DbClass
    {
        private static MySqlConnection conn;
        private static MySqlCommand command;
        
        public static bool EstablishConnection()
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
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //public static UserDTO Login(string userName, string passWord)
        //{
        //    conn.Open();

        //    string sql = "SELECT * FROM users WHERE username='" + userName + "'AND password='" + passWord + "'";

        //    command = new MySqlCommand(sql, conn);
        //    MySqlDataReader reader = command.ExecuteReader();

        //    DTO.UserDTO userDTO = new DTO.UserDTO();

        //    while (reader.Read())
        //    {
        //        userDTO.Id = Convert.ToInt32(reader["id"]);
        //        userDTO.Username = Convert.ToString(reader["username"]);
        //        userDTO.EmployeeId = Convert.ToInt32(reader["employee_id"]);


        //        // User user = new User(reader["username"].ToString());
        //        //   user.Username = ;
        //        //string isEmployee = reader["is_employee"].ToString();
        //        //if (isEmployee == "1") user.IsEmployee = true; 
        //    }
        //    conn.Close();

        //    //Classes.Session.setSession(user);

        //    return userDTO;
        //}

        public static bool InsertCar(Car car)
        {
            try
            {
                conn.Open();
                string sql = "INSERT INTO cars (brand, model, construction_year, price) VALUES (@brand, @model, @construction_year, @price)";

                command = new MySqlCommand(sql, conn);
                command.Parameters.AddWithValue("@brand", car.Brand);
                command.Parameters.AddWithValue("@model", car.Model);
                command.Parameters.AddWithValue("@construction_year", car.ConstructionYear);
                command.Parameters.AddWithValue("@price", car.Price);
                command.ExecuteReader();
                
                conn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if(conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }

        }

        public static List<Car> GetAllCars()
        {
            List<Car> cars = new List<Car>();

            try
            {
                conn.Open();
                string sql = "SELECT * FROM cars;";

                command = new MySqlCommand(sql, conn);

                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Car car = new Car();
                    car.Model = Convert.ToString(reader["model"]);
                    car.Brand = Convert.ToString(reader["brand"]);
                    car.ConstructionYear = Convert.ToInt32(reader["construction_year"]);
                    cars.Add(car);
                }
                conn.Close();

                return cars;
            }
            catch (Exception)
            {
                return cars;
            }
        }

    }
}
