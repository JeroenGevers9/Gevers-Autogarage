using System;
using System.Collections.Generic;
using System.Text;

namespace GeversData
{
    public class CarDTO
    {
		public string Model { get; set; }
		public string Brand { get; set; }
		public int ConstructionYear { get; set; }
		public decimal Price
		{
			get; //{ return price; }
			protected set;// { price = value; }
		}

		public void setPrice(decimal purchasePrice, int mileage)
		{
			if (mileage == 0 && this.ConstructionYear == 0)
			{
				Price = purchasePrice;
			}
			else
			{
				// Calculate price based on purchasePrice, milage (Kilometerstand) and constructionYear of the car.
			}
		}
	}
}
