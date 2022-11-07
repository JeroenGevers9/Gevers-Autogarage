using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gevers_Autogarage.Classes
{
	public class Car
	{
		private string model;

		public string Model
		{
			get { return model; }
			set { model = value; }
		}

		private string brand;

		public string Brand
		{
			get { return brand; }
			set { brand = value; }
		}

		private int construction_year;

		public int ConstructionYear
		{
			get { return construction_year; }
			set { construction_year = value; }
		}

		//private decimal price;
		public decimal Price
		{
			get; //{ return price; }
			private set;// { price = value; }
		}

		public void setPrice(string price)
		{
			Price = decimal.Parse(price);
		}

		public override string ToString()
		{
			return brand.ToString() + " " + model.ToString();
		}


	}
}
