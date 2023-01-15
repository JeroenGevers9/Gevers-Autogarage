using System;
using System.Collections.Generic;
using System.Text;

namespace GeversLogic
{
    public class Car
    {
		public List<Accessoire> accessoires;
		private readonly ICarStorage carStorage;
		public int Id { get; set; }
		public string Model { get; set; }
		public string Brand { get; set; }
		public int ConstructionYear { get; set; }
		public decimal Price { get; set; }

		public Car(ICarStorage _carStorage)
		{
			this.carStorage = _carStorage;
		}

		public Car getCar()
		{
			// get & set all variables as private and set them in this function (and setCar function).
			return this;
		}

		public decimal getAccessoireTotal()
		{
			decimal total = 0;
			if(this.accessoires != null && this.accessoires.Count > 0)
			{
				foreach (Accessoire accessoire in this.accessoires)
				{
					total = total + accessoire.Price;
				}
			}
			return total;
		}

		public List<Accessoire> getAllAccessoires()
		{
			foreach (Accessoire accessoire in carStorage.GetAccessoires())
			{
				accessoires.Add(accessoire);
			}
			return accessoires;
		}

		public void addAccessoires(List<Accessoire> accessoires)
		{
			this.accessoires = accessoires;
		}

		public override string ToString()
		{
			return this.Brand.ToString() + " " + this.Model.ToString();
		}


	}
}
