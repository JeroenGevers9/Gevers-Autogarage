using System;
using System.Collections.Generic;
using System.Text;

namespace GeversLogic
{
    public class Car
    {
		public Car()
		{
			//this.Model = car.Model;
			//this.Brand = car.Brand;
			//this.ConstructionYear = car.ConstructionYear;
			//this.Price = car.Price;
		}

		public void addAccessoire()
		{
			// TODO: Implement addAccessoire(s) to AccessoireDTO (who sets it in database).
		}

		public override string ToString()
		{
			return this.Brand.ToString() + " " + this.Model.ToString();
		}

		public string Model { get; set; }
		public string Brand { get; set; }
		public int ConstructionYear { get; set; }
		protected decimal Price
		{
			get; //{ return price; }
			set;// { price = value; }
		}



	}
}
