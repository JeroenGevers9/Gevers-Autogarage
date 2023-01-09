using GeversData;
using GeversLogic;
using GeversView;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace GeversView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InstantiateFactory();
        }

        public MainWindow(User user)
        {
            InitializeComponent();
            InstantiateFactory();
            loggedInUser = user;
            buttonVisibility();
        }

        Company _company;
        Car car;
        GeversLogic.Order order;
        User loggedInUser;

        RepositoryFactory factory;

        ICarStorage carStorage;
        IOrderStorage orderStorage;
        ICompanyStorage companyStorage;
        IUserStorage userStorage;

        private void btnTradeValue_Click(object sender, RoutedEventArgs e)
        {
            TradeValueWindow tvw = new TradeValueWindow();
            tvw.Show();
            this.Close();
        }

        private void btnCreateCar_Click(object sender, RoutedEventArgs e)
        {
            CarWindow cw = new CarWindow(factory.GetCarStorage()) ;
            cw.Show();
            this.Close();
        }
        private void btnCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            if(loggedInUser != null)
            {
                order.User = loggedInUser;
                OrderWindow ow = new OrderWindow(factory, order);
                ow.Show();
                this.Close();
            }
            else
            {
                Login loginWindow = new Login(_company, userStorage);
                loginWindow.Show();
                this.Close();
            }
      
        }

        private void btnShowOrders_Click(object sender, RoutedEventArgs e)
        {

        }


        private void InstantiateFactory()
        {
            string server = ConfigurationManager.AppSettings["server"];
            string database = ConfigurationManager.AppSettings["database"];
            string userId = ConfigurationManager.AppSettings["userId"];
            string password = ConfigurationManager.AppSettings["password"];
            factory = new RepositoryFactory(server, database, userId, password);

            InstantiateCompanyRepo();
            InstantiateCarRepo();
            InstantiateOrderRepo();
            InstantiateUserRepo();
        }

        private void InstantiateCompanyRepo()
        {
            companyStorage = factory.GetCompanyStorage();
            _company = new Company(companyStorage);
        }

        private void InstantiateCarRepo()
        {
            carStorage = factory.GetCarStorage();
            car = new Car(carStorage);
        }
        private void InstantiateOrderRepo()
        {
            orderStorage = factory.GetOrderStorage();
            order = new GeversLogic.Order(orderStorage, carStorage);
        }
        private void InstantiateUserRepo()
        {
            userStorage = factory.GetUserStorage();
            loggedInUser = new GeversLogic.User(userStorage);
        }


        private void buttonVisibility()
        {
            if (this.loggedInUser.isEmployee())
            {
                btnLogin.Visibility = Visibility.Hidden;
                btnShowOrders.Visibility = Visibility.Visible;
                btnCreateCar.Visibility = Visibility.Visible;
                lblUsername.Content = loggedInUser.Username;

            }
            else if (this.loggedInUser != null)
            {
                btnLogin.Visibility = Visibility.Hidden;
                btnShowOrders.Visibility = Visibility.Hidden;
                btnCreateCar.Visibility = Visibility.Hidden;
                lblUsername.Content = loggedInUser.Username;
            }
            else
            {
                btnShowOrders.Visibility = Visibility.Hidden;
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login(_company, userStorage);
            loginWindow.Show();
            this.Close();
        }

        private void btnCreateLeasePlan_Click(object sender, RoutedEventArgs e)
        {
            LeaseWindow leaseWindow= new LeaseWindow();
            leaseWindow.Show();
            this.Hide();
        }
    }
}
