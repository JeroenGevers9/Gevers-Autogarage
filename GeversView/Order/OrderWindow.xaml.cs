﻿using GeversData;
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
       
        public OrderWindow(RepositoryFactory _factory)
        {
            InitializeComponent();
            factory = _factory;
            companyStorage = factory.GetCompanyStorage();
            carStorage = factory.GetCarStorage();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private void btnAddCar_Click(object sender, RoutedEventArgs e)
        {
            CarWindow carWindow = new CarWindow();
            carWindow.Show();
        }
    }
}