﻿using System;
using System.Collections.Generic;
using System.Data;
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
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.Server = "127.0.0.1";
                builder.UserID = "root";
                //builder.Password = "Lekkeretaart";
                builder.Password = "";
                builder.Database = "garage-gevers";
                conn = new SqlConnection(builder.ToString());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}