using GeversData;
using GeversLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
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
    /// Interaction logic for OrderView.xaml
    /// </summary>
    public partial class OrderView : Window
    {
        RepositoryFactory factory;
        ICompanyStorage companyStorage;
        public OrderView(RepositoryFactory _factory)
        {
            InitializeComponent();
            factory = _factory;
            companyStorage = factory.GetCompanyStorage();

            LoadOrders();
        }


        public void LoadOrders()
        {
            DataTable dt = new DataTable();
            //dgOrders.Columns.Add(new DataGridColumn("OrderNummer", typeof(int)));
            //dgOrders.Columns.Add(new DataGridColumn("Gebruiker", typeof(string)));
            //dgOrders.Columns.Add(new DataGridColumn("Totaalprijs", typeof(int)));
            //dgOrders.Columns.Add(new DataGridColumn("Werknemer", typeof(int)));


            //foreach (GeversLogic.Order order in companyStorage.GetOrders())
            //{
            //    orderRow.Children.Add()
            //    dgOrders..Add(order.OrderNr, order.User.Username, order.getTotalPrice(), order.User.EmployeeNr);
            //}
            //dgOrders.Items.Add()
            //dgOrders.ItemsSource = dt.DefaultView;
        }
    }
}
