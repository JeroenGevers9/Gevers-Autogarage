using GeversData;
using GeversLogic;
using System;
using System.Collections.Generic;
using System.Windows;

namespace GeversView.Order
{
    /// <summary>
    /// Interaction logic for CarWindow.xaml
    /// </summary>
    public partial class AddCar : Window
    {
        ICompanyStorage companyStorage;
        ICarStorage carStorage;

        public AddCar(ICompanyStorage _companyStorge, ICarStorage _carStorage)
        {
            InitializeComponent();
            companyStorage = _companyStorge;
            carStorage = _carStorage;
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
            foreach (Car car in cars)
            {
                cbCars.Items.Add(car);
            }
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
            OrderWindow orderWindow = new OrderWindow(companyStorage, carStorage);
            orderWindow.Show();
        }
    }
}
