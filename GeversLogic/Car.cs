using GeversData;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeversLogic
{
    public class Car
    {

        // getCarDTO
        private List<Car> cars = new List<Car>();
        List<CarDTO> carDTOs = new List<CarDTO>();


        Repository repo = new Repository();

		public List<Car> getAllCars()
        {

            foreach(CarDTO dto in Repository.getCarDTOs())
            {
                Car car = new Car();
                car.Model = dto.Model;
				car.Brand = dto.Brand;
				car.Price = dto.Price;
				car.ConstructionYear = dto.ConstructionYear;

				cars.Add(car);
			}

			return cars;
		}

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
