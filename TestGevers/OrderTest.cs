using GeversLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace TestGevers
{
    [TestClass]
    public class UnitTest1
    {
        IOrderStorage orderStorage = new Mock<IOrderStorage>().Object;
        ICarStorage carStorage = new Mock<ICarStorage>().Object;
        IUserStorage userStorage = new Mock<IUserStorage>().Object;

        User user;
        Car car;

        [TestMethod]
        public void CalculateOrderWithoutDiscount()
        {
            // Arrange
            int totalPrice = 50000; 

            Order order = new Order(orderStorage, userStorage);
            car = new Car(carStorage);
            car.Brand = "Audi";
            car.Model = "A7";
            car.Price = 50000;

            // Act
            order.addCar(car);

            //Assert
            Assert.AreEqual(totalPrice, order.getTotalPrice());
        }


        [TestMethod]
        public void CalculateOrderWithDiscount()
        {
            // Arrange
            int totalPrice = 29750;

            user = new User(userStorage);
            user.EmployeeNr = 12345;
            user.Username = "Test 1";

            Employee employee = new Employee(userStorage, user);
            employee.Function = 1;
            user.Employee = employee;

            car = new Car(carStorage);
            car.Brand = "Audi";
            car.Model = "A7";
            car.Price = 50000;

            Order order = new Order(orderStorage, userStorage);
            order.User = user;

            // Act
            order.addCar(car);

            //Assert
            Assert.AreEqual(totalPrice, order.getTotalPrice());
            Assert.AreEqual(15, user.Employee.GetDiscountAmount());
        }

    }
}
