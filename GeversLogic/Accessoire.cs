using System;
using System.Collections.Generic;
using System.Text;

namespace GeversLogic
{
    public class Accessoire
    {
        public int CarId { get; private set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public void setCarId(int carId)
        {
            this.CarId = carId;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
