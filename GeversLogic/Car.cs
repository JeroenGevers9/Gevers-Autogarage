using System;
using System.Collections.Generic;
using System.Text;

namespace GeversLogic
{
    public class Car
    {
		public Car(Car car)
		{
			this.Model = car.Model;
			this.Brand = car.Brand;
			this.ConstructionYear = car.ConstructionYear;
			this.Price = car.Price;
		}

		public void addAccessoire()
		{
			// TODO: Implement addAccessoire(s) to AccessoireDTO (who sets it in database).
		}

		public override string ToString()
		{
			return this.Brand.ToString() + " " + this.Model.ToString();
		}

		private string Model { get; set; }
		private string Brand { get; set; }
		private int ConstructionYear { get; set; }
		protected decimal Price
		{
			get; //{ return price; }
			set;// { price = value; }
		}



	}
}
