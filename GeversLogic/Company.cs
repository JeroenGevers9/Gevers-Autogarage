using GeversData;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeversLogic
{
    public class Company
    {
        // getCarDTO
        private List<Car> cars = new List<Car>();

        public List<Car> getAllCars()
        {
            foreach (CarDTO dto in Repository.getCarDTOs())
            {
                Car car = new Car(dto);
                cars.Add(car);
            }

            return cars;
        }

        public string Name { get; private set; }

        public void setName(string companyName)
        {
            this.Name = companyName;
        }

    }
}
