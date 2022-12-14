using GeversData;
using GeversLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace GeversView.Order
{
    /// <summary>
    /// Interaction logic for CarWindow.xaml
    /// </summary>
    public partial class AddCar : Window
    {
        RepositoryFactory factory;
        ICompanyStorage companyStorage;
        ICarStorage carStorage;
        IOrderStorage orderStorage;
        Car car;
        GeversLogic.Order order;

        public AddCar(RepositoryFactory _factory, GeversLogic.Order _order)
        {
            InitializeComponent();

            order = _order;
            factory = _factory;
            companyStorage = factory.GetCompanyStorage();
            carStorage = factory.GetCarStorage();
            orderStorage = factory.GetOrderStorage();
            loadData();
        }

        private void loadData()
        {
            loadCars();
            loadAccessoires();
        }
        private void loadCars()
        {
            List<Car> cars = companyStorage.GetCars();

            if(order.Cars != null && order.Cars.Count > 0)
            {
                //Exclude the order.Cars from cars (because they are already added to the order);
                List<Car> newCarList = cars.Except(order.Cars).ToList();

                //List<Car> results = cars.Where(i => !order.Cars.Contains(i));

                //List<Car> tempCarList = cars.Where(car => !order.Cars.Contains(car)).ToList();
                //List<Car> tempCarList = cars.Except(order.Cars).ToList();
            }

            foreach (Car car in cars)
            {
                cbCars.Items.Add(car);
            }
        }

        private bool getListDiff(List<Car> carsFromDatabase, List<Car> carsFromOrder)
        {
            var firstNotSecond = carsFromOrder.Except(carsFromDatabase).ToList();
            var secondNotFirst = carsFromDatabase.Except(carsFromOrder).ToList();

            return !firstNotSecond.Any() && !secondNotFirst.Any();
        }

        private void loadAccessoires()
        {
            List<Accessoire> accessoires = carStorage.GetAccessoires();
            foreach (Accessoire accessoire in accessoires)
            {
                lstOptions.Items.Add(accessoire);
            }

        }

        private void btnAddCarToOrder_Click(object sender, RoutedEventArgs e)
        {
            // Add car to order, if order doesnt exists --> create order
            if ((Car)cbCars.SelectedItem == null)
            {
                MessageBox.Show("Selecteer een auto om toe te voegen aan het order");
            }
            else
            {
                car = (Car)cbCars.SelectedItem;

                if (lstOptions.SelectedItems.Count > 0 )
                {
                    IList items = lstOptions.SelectedItems;
                    car.addAccessoire(items.Cast<Accessoire>().ToList());
                }
                order.addCar(car);
                
                OrderWindow orderWindow = new OrderWindow(factory, order);
                orderWindow.Show();
                this.Close();
            }
        }
    }
}
