﻿using MySql.Data.MySqlClient;
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

        public static User Login(string userName, string passWord)
        {
            conn.Open();

            string sql = "SELECT * FROM users WHERE username='" + userName + "'AND password='" + passWord + "'";

            command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            User user = new User();
           
            while (reader.Read())
            {
                user.Username = reader["username"].ToString();
                string isEmployee = reader["is_employee"].ToString();
                if (isEmployee == "1") user.IsEmployee = true; 
            }
            conn.Close();

            Classes.Session.setSession(user);

            return user;
        }

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
        
    }
}
