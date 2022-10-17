using System;
using System.Collections.Generic;
using System.Text;

namespace GeversLogic
{
    public class Customer
    {
		private string username;

		public string Username
		{
			get { return username; }
			set { username = value; }
		}


		// getCarDTO
		List<Car> cars = new List<Car>();
		List<CarDTO> carDTOs = new List<CarDTO>();
		GeversData.Repository.getCarDTO();

	}
}
