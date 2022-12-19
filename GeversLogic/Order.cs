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
        public User User { get; set; }
        public Company Company { get; set; }
        public decimal TotalPrice { get; private set; }

        public decimal calculateTotal()
        {
            decimal total = 0;
            if(this.Cars.Count > 0)
            {
                foreach(Car car in this.Cars)
                {
                    total = total + car.Price;
                    total = total + car.getAccessoireTotal();
                }
            }

            return total;
        }

        public bool Save()
        {
            if(this != null && this.Cars.Count > 0) {
                return orderStorage.SaveOrder(this);
            }
            return false;
        }
        
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
