using Gevers_Autogarage.Classes;
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
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public OrderWindow()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            List<Car> cars = DbClass.GetAllCars();
            foreach (Car car in cars)
            {
                cbCars.Items.Add(car);
            }


            Accessoires accessoires;
            foreach (string accessoire in Enum.GetNames(typeof(Accessoires)))
            {
                lstOptions.Items.Add(accessoire);
            }

            User user = new User();
        }

    }
}
