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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gevers_Autogarage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            buttonVisibility();
        }

        private void btnTradeValue_Click(object sender, RoutedEventArgs e)
        {
            TradeValueWindow tvw = new TradeValueWindow();
            tvw.Show();
            this.Close();
        }

        private void btnCreateCar_Click(object sender, RoutedEventArgs e)
        {
            CarWindow cw = new CarWindow();
            cw.Show();
            this.Close();
        }

        private void btnShowOrders_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonVisibility()
        {
            if (Classes.Session.IsEmpmloyee)
            {
                btnLogin.Visibility = Visibility.Hidden;
                btnShowOrders.Visibility = Visibility.Visible;
                lblUsername.Content = Classes.Session.Username;

            }
            else if(Classes.Session.LoggedIn)
            {
                btnLogin.Visibility = Visibility.Hidden;
                btnShowOrders.Visibility = Visibility.Hidden;
                lblUsername.Content = Classes.Session.Username;
            }
            else
            {
                btnShowOrders.Visibility = Visibility.Hidden;
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            loginWindow.Show();
            this.Close();
        }
    }
}
