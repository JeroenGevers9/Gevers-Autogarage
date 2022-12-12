using System;
using System.Collections.Generic;
using System.Text;

namespace GeversLogic
{
    public class Car
    {

		public List<Accessoire> accessoires;
		public ICarStorage carStorage;

		public Car(ICarStorage _carStorage)
		{
			this.carStorage = _carStorage;
		}

		public int Id{ get; }
		public string Model { get; set; }
		public string Brand { get; set; }
		public int ConstructionYear { get; set; }
		public decimal Price { get; set; }


		public List<Accessoire> getAllAccessoires()
		{
			foreach (Accessoire accessoire in carStorage.GetAccessoires())
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
