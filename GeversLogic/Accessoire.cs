using System;
using System.Collections.Generic;
using System.Text;

namespace GeversLogic
{
    public class Accessoire
    {
        private int CarId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
