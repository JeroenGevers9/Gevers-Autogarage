using System;
using System.Collections.Generic;
using System.Text;

namespace GeversLogic
{
    public class Company 
    {
        private ICompanyStorage _companyRepository;
        private List<Car> cars = new List<Car>();
        private List<User> users = new List<User>();


        public Company(ICompanyStorage companyRepository)
        {
            _companyRepository = companyRepository;
        }


        public List<Car> getAllCars()
        {
            foreach (Car car in _companyRepository.GetCars())
            {
                cars.Add(car);
            }
            return cars;
        }

        public List<User> getUsers()
        {
            foreach (User user in _companyRepository.GetUsers())
            {
                users.Add(user);
            }
            return users;
        }
                     

        public string Name { get; private set; }

        public void setName(string companyName)
        {
            this.Name = companyName;
        }

    }
}
