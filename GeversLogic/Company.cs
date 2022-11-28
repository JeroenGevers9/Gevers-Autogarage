using System;
using System.Collections.Generic;
using System.Text;

namespace GeversLogic
{
    public class Company 
    {
        private ICompanyStorage _companyRepository;
        public Company(ICompanyStorage companyRepository)
        {
            _companyRepository = companyRepository;
        }

        // getCarDTO
        private List<Car> cars = new List<Car>();

        public List<Car> getAllCars()
        {
            foreach (Car c in _companyRepository.GetCars())
            {
                Car car = new Car(c);
                cars.Add(car);
            }

            return cars;
        }

        //public List<User> getUsers()
        //{
        //    List<User> users = new List<User>();
        //    foreach (UserDTO userDTO in _userRepository.GetUsers())
        //    {
        //        User user = new User();
        //        users.Add(user);
        //    }
        //    return users;
        //}





        public string Name { get; private set; }

        public void setName(string companyName)
        {
            this.Name = companyName;
        }

    }
}
