using System;
using System.Collections.Generic;
using System.Text;

namespace GeversData
{
    public class CarDTO
    {
        public string Model { get; set; }
        public string Brand{ get; set; }
        public decimal Price { get; set; }

        public int ConstructionYear { get; set; }
    }
}
