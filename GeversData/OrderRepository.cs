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


                string sql = "SELECT * FROM cars WHERE (cars.id IN(SELECT car_id FROM car_order))";

                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Car car = new Car(carStorage);
                    car.Id = Convert.ToInt32(reader["id"]);
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
                string sql = "INSERT INTO orders (user_id, total) VALUES (@user_id, @total)";              

                MySqlCommand command = new MySqlCommand(sql, conn);

                command.Parameters.AddWithValue("@user_id", order.User.Id);
                command.Parameters.AddWithValue("@total", order.getTotalPrice());
                command.ExecuteReader();

                int orderId = Convert.ToInt32(command.LastInsertedId);

                if (order.Cars.Count > 0)
                {
                    saveCarsToOrder(order.Cars, orderId);

                    return true;
                }
                else
                {
                    return true;
                }
            }
            finally
            {
                conn.Close();
            }
        }

        private void saveCarsToOrder(List<Car> cars, int orderId)
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

                    command.ExecuteReader();

                    foreach (Accessoire accessoire in car.accessoires)
                    {
                        saveAccessoiresToOrder(car, accessoire);
                    }
                }
            }
            finally
            {
                conn.Close();
            }
        }

        private void saveAccessoiresToOrder(Car car, Accessoire accessoire)
        {
            MySqlConnection conn = this.GetDatabaseConnection(true);
            try
            {
                string sql = "INSERT INTO car_accessoire (accessoire_id, car_id) VALUES (@accessoire_id, @car_id)";
                MySqlCommand command = new MySqlCommand(sql, conn);

                command.Parameters.AddWithValue("@accessoire_id", accessoire.Id);
                command.Parameters.AddWithValue("@car_id", car.Id);

                command.ExecuteReader();
            }
            finally
            {

                conn.Close();
            }
        }

    }
}
