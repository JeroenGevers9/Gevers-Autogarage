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

namespace Gevers_Autogarage
{
    /// <summary>
    /// Interaction logic for CarWindow.xaml
    /// </summary>
    public partial class CarWindow : Window
    {
        public CarWindow()
        {
            InitializeComponent();
        }

        private void btnSaveCar_Click(object sender, RoutedEventArgs e)
        {
            Classes.Car car = new Classes.Car();

            car.Brand = tbxBrand.Text;
            car.Model = tbxModel.Text;
            car.setPrice(tbxPrice.Text);
            car.ConstructionYear = int.Parse(tbxConstructionYear.Text);

            if(Classes.DbClass.InsertCar(car))
            {
                MessageBox.Show("Auto successvol toegevoegd");
                MainWindow mw = new MainWindow();
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
