using System;
using System.Collections.Generic;
using System.Text;

namespace GeversLogic
{
    public class Car
    {

		public List<Accessoire> accessoires;
		private ICarStorage _carStorage;


		public string Model { get; set; }
		public string Brand { get; set; }
		public int ConstructionYear { get; set; }
		protected decimal Price
		{
			get; //{ return price; }
			set;// { price = value; }
		}


		public List<Accessoire> getAllAccessoires()
		{
			foreach (Accessoire accessoire in _carStorage.GetAccessoires())
			{
				accessoires.Add(accessoire);
			}
			return accessoires;
		}

		public void addAccessoire()
		{
			// TODO: Implement addAccessoire(s) to AccessoireDTO (who sets it in database).
		}

		public override string ToString()
		{
			return this.Brand.ToString() + " " + this.Model.ToString();
		}


	}
}
