using GeversData;
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
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        RepositoryFactory factory;
        ICompanyStorage companyStorage;
        ICarStorage carStorage;
        GeversLogic.Order order;
        public OrderWindow(RepositoryFactory _factory, GeversLogic.Order _order)
        {
            InitializeComponent();
            factory = _factory;
            order = _order;
            companyStorage = factory.GetCompanyStorage();
            carStorage = factory.GetCarStorage();
            loadOrder();
        }

        private void loadOrder()
        {
            if(order.Cars != null && order.Cars.Count > 0)
            {
                foreach(Car car in order.Cars)
                {
                    DockPanel carRow = new DockPanel();
                    Label carName = new Label();
                    carName.Content = "- " + car.ToString();
                    carName.FontSize = 20;
                    carName.FontWeight = FontWeights.Bold;

                    carRow.Children.Add(carName);

                    if (car.accessoires.Count > 0)
                    {
                        StackPanel stack = new StackPanel();
                        foreach (Accessoire accessoire in car.accessoires)
                        {
                            Label accessoireName = new Label();
                            accessoireName.Content = accessoire.ToString();
                            stack.Children.Add(accessoireName);
                        }
                        carRow.Children.Add(stack);
                    }

                    stackCars.Children.Add(carRow);
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void btnAddCar_Click(object sender, RoutedEventArgs e)
        {
            Order.AddCar carWindow = new Order.AddCar(factory, order);
            carWindow.Show();
            this.Close();
        }

        private void btnSaveOrder_Click(object sender, RoutedEventArgs e)
        {
            decimal total = order.getTotalPrice();

            if (order.Save())
            {
                MessageBox.Show("Order saved");
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
            }

            MessageBox.Show("Something went wrong, the order could not be saved");
        }
    }
}
