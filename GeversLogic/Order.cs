using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeversLogic
{
    public class Order
    {
        private readonly IOrderStorage orderStorage;
        private readonly IUserStorage userStorage;

        public int OrderNr { get; set; }
        public List<Car> Cars { get; set; }
        public User User { get; set; }
        public Company Company { get; set; }

        private decimal totalPrice;

        public void setPrice(decimal price)
        {
            this.totalPrice = price;
        }
        public decimal getTotalPrice()
        {
            decimal total = 0;

            if (totalPrice != 0) return totalPrice;

            total = calculateCarTotal(total);

            total = applyDiscount(total);

            return total;
        }

        private decimal calculateCarTotal(decimal total)
        {
            if (this.Cars != null && this.Cars.Count > 0)
            {
                foreach (Car car in this.Cars)
                {
                    total = total + car.Price;
                    total = total + car.getAccessoireTotal();
                }
            }

            return total;
        }

        private decimal applyDiscount(decimal total)
        {

            List<string> discountClasses = getAllDiscountClasses();
            foreach (string discountClass in discountClasses)
            {
                int discountAmount = 0;

                if (discountClass == "GeversLogic.Employee")
                {
                    var objectType = Type.GetType(discountClass);
                    var objectClass = Activator.CreateInstance(objectType, new object[] {userStorage, User }) as IDiscountable;

                    Employee employee = new Employee(userStorage, User);

                    if(this.User != null && this.User.isEmployee())
                    {
                        discountAmount = objectClass.GetDiscountAmount();
                    }
                }
                else
                {
                    var objectType = Type.GetType(discountClass);
                    var objectClass = Activator.CreateInstance(objectType) as IDiscountable;

                    discountAmount = objectClass.GetDiscountAmount();
                }

                total = reCalculateTotalWithDiscount(total, discountAmount);
               
            }

            return total;
        }

        private decimal reCalculateTotalWithDiscount(decimal total, int discountAmount)
        {
            total = (total / 100) * (100 - discountAmount);

            return total;
        }

        private List<string> getAllDiscountClasses()
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(IDiscountable).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => x.FullName).ToList();
        }

        public bool Save()
        {
            if(this.Cars != null && this.Cars.Count > 0) {
                return orderStorage.SaveOrder(this);
            }
            return false;
        }
        
        public Order(IOrderStorage _orderStorage, IUserStorage _userStorage)
        {
            orderStorage = _orderStorage;
            userStorage = _userStorage;
        }


        public List<Car> getAllCars()
        {
            foreach (Car car in orderStorage.GetCars())
            {
                Cars.Add(car);
            }
            return Cars;
        }

        public Order addCar(Car car)
        {
            if(Cars == null)
            {
                Cars = new List<Car>();
            }
            Cars.Add(car);

            return this;
        }

    }
}
