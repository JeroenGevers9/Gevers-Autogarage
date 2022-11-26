using GeversLogic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
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
      

        Company company;

        public LeaseWindow()
        {
            InitializeComponent();
            initializeDatabase();
            getCarList();
        }

        private void initializeDatabase()
        {
            string server = ConfigurationManager.AppSettings["server"];
            string database = ConfigurationManager.AppSettings["database"];
            string userId = ConfigurationManager.AppSettings["userId"];
            string password = ConfigurationManager.AppSettings["password"];

            GeversData.UserRepository repository = new GeversData.UserRepository(server, database, userId, password);
            company = new Company(repository);
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
            foreach(Car car in company.getAllCars())
            {
                lbxCars.Items.Add(car);
            }
        }
    }
}
