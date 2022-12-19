using System;
using System.Collections.Generic;
using System.Text;

namespace GeversLogic
{
    public class Company 
    {
        private ICompanyStorage _CompanyRepository;
        private List<Car> Cars = new List<Car>();
        private List<User> Users = new List<User>();
        private string Name;


        public Company(ICompanyStorage companyRepository)
        {
            _CompanyRepository = companyRepository;
        }


        public List<Car> getAllCars()
        {
            foreach (Car car in _CompanyRepository.GetCars())
            {
                Cars.Add(car);
            }
            return Cars;
        }

        public List<User> getUsers()
        {
            foreach (User user in _CompanyRepository.GetUsers())
            {
                Users.Add(user);
            }
            return Users;
        }

        public void setName(string companyName)
        {
            this.Name = companyName;
        }

    }
}
