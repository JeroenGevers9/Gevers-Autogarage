using System;
using System.Collections.Generic;
using System.Text;

namespace GeversLogic
{
    public class Order
    {
        public List<Car> cars{ get; set; }
        public User user { get; set; }
        public Company company{ get; set; }

    }
}
