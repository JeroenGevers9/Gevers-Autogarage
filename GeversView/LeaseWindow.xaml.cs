using GeversLogic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GeversView
{
    /// <summary>
    /// Interaction logic for LeaseWindow.xaml
    /// </summary>
    public partial class LeaseWindow : Window
    {
        List<Car> cars = new List<Car>();
        Car car = new Car();

        public LeaseWindow()
        {
            InitializeComponent();
            getCarList();
        }

        private void onChange(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem lbi = ((sender as ListBox).SelectedItem as ListBoxItem);
            calculateTotal();
        }

        protected decimal calculateTotal()
        {
            decimal total = 0;



            return total;
        }

        private void getCarList()
        {
            List<Car> cars = car.getAllCars();
            foreach(Car car in cars)
            {
                lbxCars.Items.Add(car);
            }
        }
    }
}
