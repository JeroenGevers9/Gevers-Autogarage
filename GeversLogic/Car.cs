using GeversData;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeversLogic
{
    public class Car : CarDTO
    {
		public Car(CarDTO carDTO)
		{
			this.Model = carDTO.Model;
			this.Brand = carDTO.Brand;
			this.ConstructionYear = carDTO.ConstructionYear;
			this.Price = carDTO.Price;
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
