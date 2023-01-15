using System;
using System.Collections.Generic;
using System.Text;

namespace GeversLogic
{
    public class Company : IDiscountable, ICompanyStorage
    {
        private ICompanyStorage _CompanyRepository;
        private List<Car> Cars = new List<Car>();
        private List<User> Users = new List<User>();
        private List<Order> Orders = new List<Order>();

        private string Name;


        public Company(ICompanyStorage companyRepository)
        {
            _CompanyRepository = companyRepository;
        }
        public Company()
        {
        }


        public List<Car> GetCars()
        {
            foreach (Car car in _CompanyRepository.GetCars())
            {
                Cars.Add(car);
            }
            return Cars;
        }

        public List<Order> GetOrders()
        {
            foreach (Order order in _CompanyRepository.GetOrders())
            {
                Orders.Add(order);
            }
            return Orders;
        }

        // New years discount for January
        public int GetDiscountAmount()
        {
            if(DateTime.Now.Month == 1)
            {
                return 30;
            }
            return 0;
        }

        public List<User> GetUsers()
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
