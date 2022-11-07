using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace GeversData
{
    public class Repository
    {
        private static SqlConnection conn;
        private static SqlCommand command;
        private static DataTable dt;
        private static SqlDataAdapter sda;

        public static bool EstablishConnection()
        {
            string connString = @"Server=127.0.0.1\myInstanceName;Database=garage-gevers;Integrated Security=true;";
            try
            {
                conn = new SqlConnection();
                conn.ConnectionString = connString;
                conn.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            //try
            //{
            //    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            //    builder.Server = "127.0.0.1";
            //    builder.UserID = "root";
            //    //builder.Password = "Lekkeretaart";
            //    builder.Password = "";
            //    builder.Database = "garage-gevers";
            //    conn = new SqlConnection(builder.ToString());
            //    return true;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}
        }

        public static UserDTO Login(string userName, string passWord)
        {
            UserDTO userDTO = new UserDTO();

            if (EstablishConnection())
            {
                string sql = "SELECT * FROM users WHERE username='" + userName + "'AND password='" + passWord + "'";

                command = new SqlCommand(sql, conn);
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    userDTO.Id = Convert.ToInt32(reader["id"]);
                    userDTO.Username = Convert.ToString(reader["username"]);
                    userDTO.EmployeeId = Convert.ToInt32(reader["employee_id"]);


                    // User user = new User(reader["username"].ToString());
                    //   user.Username = ;
                    //string isEmployee = reader["is_employee"].ToString();
                    //if (isEmployee == "1") user.IsEmployee = true; 
                }

                //Classes.Session.setSession(user);
            }
            conn.Close();

            return userDTO;

        }


        public static List<CarDTO> getCarDTOs()
        {
            List<CarDTO> carDTOs = new List<CarDTO>();
            try
            {
                conn.Open();
                string sql = "SELECT * FROM cars;";

                command = new SqlCommand(sql, conn);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    CarDTO car = new CarDTO();
                    car.Model = Convert.ToString(reader["model"]);
                    car.Brand = Convert.ToString(reader["brand"]);
                    car.ConstructionYear = Convert.ToInt32(reader["construction_year"]);
                    carDTOs.Add(car);
                }
                conn.Close();

                return carDTOs;
            }
            catch (Exception e)
            {
                return carDTOs;
            }
        }
    }
}
