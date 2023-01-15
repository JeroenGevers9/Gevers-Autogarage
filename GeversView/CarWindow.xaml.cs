using GeversLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for CarWindow.xaml
    /// </summary>
    public partial class CarWindow : Window
    {
        ICarStorage carStorage;
        User user;
        public CarWindow(ICarStorage _carStorage, User _user)
        {
            InitializeComponent();
            carStorage = _carStorage;
            user = _user;
        }

        private void btnSaveCar_Click(object sender, RoutedEventArgs e)
        {
            string Brand = tbxBrand.Text;
            string Model = tbxModel.Text;
            decimal Price = decimal.Parse(tbxPrice.Text);
            int ConstructionYear = int.Parse(tbxConstructionYear.Text);

            Car car = new Car(carStorage);
            car.Brand = Brand;
            car.Model = Model;
            car.Price = Price;
            car.ConstructionYear = ConstructionYear;
            

            if (carStorage.Create(car))
            {
                MessageBox.Show("Auto successvol toegevoegd");
                MainWindow mw = new MainWindow(user);
                mw.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Er ging iets mis met het toevoegen van de auto.");
            }

        }
    }
}
