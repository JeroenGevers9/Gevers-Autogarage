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
            dt.Columns.Add(new DataColumn("OrderNummer", typeof(int)));
            dt.Columns.Add(new DataColumn("Gebruiker", typeof(string)));
            dt.Columns.Add(new DataColumn("Totaalprijs", typeof(int)));
            dt.Columns.Add(new DataColumn("Werknemer", typeof(int)));


            foreach (GeversLogic.Order order in companyStorage.GetOrders())
            {
                dt.Rows.Add(order.OrderNr, order.User.Username, order.getTotalPrice(), order.User.EmployeeNr);
            }

            dgOrders.DataContext = dt.DefaultView;
        }
    }
}
