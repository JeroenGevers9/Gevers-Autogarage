using System;
using System.Collections.Generic;
using System.Text;

namespace GeversLogic
{
    public class Employee
    {
        private string EmployeeNumber;
        private IFunction Function;

        public int getDiscountAmount()
        {
            int discountAmount = 0;

            switch (Function)
            {
                case IFunction.Admin:
                    discountAmount = 50;
                    break;
                case IFunction.Administration:
                    discountAmount = 15;
                    break;
                case IFunction.Employee:
                    discountAmount = 10;
                    break;
                default:
                    discountAmount = 5;
                    break;
            }



            return discountAmount;
        }

    }
}
