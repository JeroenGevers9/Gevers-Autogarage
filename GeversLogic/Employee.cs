using System;
using System.Collections.Generic;
using System.Text;

namespace GeversLogic
{
    public class Employee : User, IDiscountable
    {
        private string EmployeeNumber;
        private IUserStorage userStorage;
        private User user;

        public Employee(IUserStorage _userStorage, User _user) : base(_userStorage)
        {
            userStorage = _userStorage;
            user = _user;
        }

        public int Function { get; set; }

        public int GetDiscountAmount()
        {
            int discountAmount = 0;

            if (this != null)
            {
                switch (user.Employee.Function)
                {
                    case (int)IFunction.Admin:
                        discountAmount = 50;
                        break;
                    case (int)IFunction.Administration:
                        discountAmount = 15;
                        break;
                    case (int)IFunction.Employee:
                        discountAmount = 10;
                        break;
                    default:
                        discountAmount = 0;
                        break;
                }
            }

            return discountAmount;
        }

    }
}
