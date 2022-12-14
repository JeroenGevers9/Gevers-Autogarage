using System;
using System.Collections.Generic;
using System.Text;

namespace GeversLogic
{
    public class Order 
    {
        IOrderStorage orderStorage;
        ICarStorage carStorage;

        public List<Car> Cars { get; set; }
        public User user { get; set; }
        public Company company { get; set; }

        public Order(IOrderStorage _orderStorage, ICarStorage _carStorage)
        {
            orderStorage = _orderStorage;
            carStorage = _carStorage;
        }


        public List<Car> getAllCars()
        {
            foreach (Car car in orderStorage.GetCars())
            {
                Cars.Add(car);
            }
            return Cars;
        }


        public Order addCar(Car car)
        {
            if(Cars == null)
            {
                Cars = new List<Car>();
            }
            Cars.Add(car);

            return this;
        }

    }
}
