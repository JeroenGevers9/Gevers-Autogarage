using GeversData;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeversLogic
{
    public class Company
    {
        private UserRepository _userRepository;
        public Company(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // getCarDTO
        private List<Car> cars = new List<Car>();

        public List<Car> getAllCars()
        {
            foreach (CarDTO dto in OldRepository.getCarDTOs())
            {
                Car car = new Car(dto);
                cars.Add(car);
            }

            return cars;
        }

        public List<User> getUsers()
        {
            List<User> users = new List<User>();
            foreach (UserDTO userDTO in _userRepository.GetUsers())
            {
                User user = new User(userDTO);
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
