using GeversLogic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeversData
{
    class OrderRepository : Repository, IOrderStorage
    {
        ICarStorage carStorage;
        IUserStorage userStorage;
        public OrderRepository(string server, string database, string userId, string password, ICarStorage _carStorage, IUserStorage _userStorage)
          : base(server, database, userId, password)
        {
            carStorage = _carStorage;
            userStorage = _userStorage;
        }

        public bool AddCar(Car car)
        {
            MySqlConnection conn = this.GetDatabaseConnection(true);
            try
            {
                string sql = "INSERT INTO cars (company_id, brand, model, price, construction_year) VALUES (@company_id, @brand, @model, @price, @construction_year)";
                MySqlCommand command = new MySqlCommand(sql, conn);

                command.Parameters.AddWithValue("@company_id", 1);
                command.Parameters.AddWithValue("@brand", car.Brand);
                command.Parameters.AddWithValue("@model", car.Model);
                command.Parameters.AddWithValue("@price", car.Price);
                command.Parameters.AddWithValue("@construction_year", car.ConstructionYear);

                command.ExecuteReader();
                return true;
            }
            finally
            {
                conn.Close();
            }
        }


        public List<User> GetUsers()
        {
            MySqlConnection conn = this.GetDatabaseConnection(true);
            try
            {
                List<User> users = new List<User>();

                string sql = "SELECT * FROM users";

                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User(userStorage);
                    user.setId(Convert.ToInt32(reader["id"]));
                    user.Username = Convert.ToString(reader["username"]);
                    //user.Employee = Convert.ToInt32(reader["employee_id"]);

                    users.Add(user);
                }
                return users;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Car> GetCars()
        {
            MySqlConnection conn = this.GetDatabaseConnection(true);
            try
            {
                List<Car> cars = new List<Car>();

                string sql = "SELECT * FROM cars";

                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Car car = new Car(carStorage);
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

        public bool SaveOrder(Order order)
        {
            MySqlConnection conn = this.GetDatabaseConnection(true);
            try
            {
                string sql;
                if (order.User != null) sql = "INSERT INTO orders (user_id, total) VALUES (@user_id, @total)";              
                else sql = "INSERT INTO orders (total) VALUES (@total)";

                MySqlCommand command = new MySqlCommand(sql, conn);

                if (order.User != null) command.Parameters.AddWithValue("@user_id", order.User.Id);

                //command.Parameters.AddWithValue("@employee_nr", 1);
                command.Parameters.AddWithValue("@total", order.getTotalPrice());

                int orderId = Convert.ToInt32(command.ExecuteScalar());

                if(order.Cars.Count > 0)
                {
                    return saveCarsToOrder(order.Cars, orderId);
                }

                // command.Parameters.AddWithValue("@cars", order.Cars);

                return true;
            }
            finally
            {
                conn.Close();
            }
        }

        private bool saveCarsToOrder(List<Car> cars, int orderId)
        {
            MySqlConnection conn = this.GetDatabaseConnection(true);
            try
            {
                foreach (Car car in cars)
                {
                    string sql = "INSERT INTO car_order (order_id, car_id) VALUES (@order_id, @car_id)";
                    MySqlCommand command = new MySqlCommand(sql, conn);

                    command.Parameters.AddWithValue("@order_id", orderId);
                    command.Parameters.AddWithValue("@car_id", car.Id);
                }
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
