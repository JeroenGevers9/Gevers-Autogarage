using System;
using System.Collections.Generic;
using System.Text;

namespace GeversLogic
{
    public interface ICompanyStorage 
    {
        List<Car> GetCars();
        List<User> GetUsers();
        List<Order> GetOrders();
    }
}
