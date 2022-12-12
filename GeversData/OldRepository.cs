using GeversLogic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace GeversData
{
    public class OldRepository
    {
        private static MySqlConnection conn;
        private static MySqlCommand command;


        public static bool CheckExist(string userName, string passWord)
        {
            User userDTO = new User();

            if (!DatabaseConnection.EstablishConnection()) return false;
            conn = DatabaseConnection.getConnection();

            string sql = "SELECT * FROM users WHERE username='" + userName + "'AND password='" + passWord + "'";

            command = new MySqlCommand(sql, conn);
            conn.Open();

            MySqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                //userDTO.id = Convert.ToInt32(reader["id"]);
                userDTO.Username = Convert.ToString(reader["username"]);
                userDTO.EmployeeId = Convert.ToInt32(reader["employee_id"]);
            }

            //Classes.Session.setSession(user);
            
            conn.Close();

            return true;
        }


        //public static List<Car> getCarDTOs()
        //{
        //    List<Car> carDTOs = new List<Car>();

        //    if (!DatabaseConnection.EstablishConnection()) return carDTOs;
        //    conn = DatabaseConnection.getConnection();

        //    try
        //    {
        //        conn.Open();
        //        string sql = "SELECT * FROM cars;";

        //        command = new MySqlCommand(sql, conn);

        //        MySqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            Car car = new Car();
        //            car.Model = Convert.ToString(reader["model"]);
        //            car.Brand = Convert.ToString(reader["brand"]);
        //            car.ConstructionYear = Convert.ToInt32(reader["construction_year"]);
        //            carDTOs.Add(car);
        //        }
        //        conn.Close();

        //        return carDTOs;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
