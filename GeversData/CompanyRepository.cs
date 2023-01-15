using GeversLogic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeversData
{
    public class CompanyRepository : Repository, ICompanyStorage
    {
        ICarStorage carStorage;
        IUserStorage userStorage;
        IOrderStorage orderStorage;
        public CompanyRepository(string server, string database, string userId, string password, ICarStorage _carStorage, IUserStorage _userStorage, IOrderStorage _orderStorage)
          : base(server, database, userId, password)
        {
            carStorage = _carStorage;
            userStorage = _userStorage;
            orderStorage = _orderStorage;
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

                string sql = "SELECT * FROM cars WHERE (cars.id NOT IN(SELECT car_id FROM car_order))";
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

        public List<Order> GetOrders()
        {
            MySqlConnection conn = this.GetDatabaseConnection(true);
            try
            {
                List<Order> orders = new List<Order>();

                string sql = "SELECT o.order_nr, o.user_id, o.total, u.username, u.employee_id FROM orders o " +
                    "LEFT JOIN users u ON o.user_id = u.id";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {

                    User user = new User(userStorage);

                    if (reader["employee_id"] != DBNull.Value) user.EmployeeNr = Convert.ToInt32(reader["employee_id"]);
                    if (reader["username"] != DBNull.Value) user.Username = Convert.ToString(reader["username"]);
                    
                    Order order = new Order(orderStorage, userStorage);
                    order.OrderNr = Convert.ToInt32(reader["order_nr"]);
                    order.setPrice(Convert.ToDecimal(reader["total"]));
                    order.User = user;
                
                    orders.Add(order);
                }
                return orders;
            }
            finally
            {
                conn.Close();
            }
        }
        

    }
}
