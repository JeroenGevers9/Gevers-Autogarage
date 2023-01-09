using System;
using System.Collections.Generic;
using System.Text;

namespace GeversLogic
{
    public class Employee
    {
        private string EmployeeNumber;
        public int Function { get; set; }

        public int getDiscountAmount()
        {
            int discountAmount;

            switch (Function)
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



            return discountAmount;
        }

    }
}
