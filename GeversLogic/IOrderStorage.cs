using System.Collections.Generic;

namespace GeversLogic
{
    public interface IOrderStorage
    {
        List<Car> GetCars();
        List<User> GetUsers();
        bool SaveOrder(Order order);
    }
}