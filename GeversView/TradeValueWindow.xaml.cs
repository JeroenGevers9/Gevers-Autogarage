﻿using System;
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
    /// Interaction logic for TradeValueWindow.xaml
    /// </summary>
    public partial class TradeValueWindow : Window
    {
        public TradeValueWindow()
        {
            InitializeComponent();
        }

        private void btnCalculateTradeValue_Click(object sender, RoutedEventArgs e)
        {
            if(tbxDroveKm.Text == "" || tbxDroveKm.Text == "0" || tbxDroveKm.Text == "" || tbxDroveKm.Text == "0" || tbxPurchaseValue.Text == "" || tbxPurchaseValue.Text == "0")
            {
                MessageBox.Show("All de boxes need to be filled");
            }

            int constructionYear = int.Parse(tbxConstructionYear.Text);
            decimal droveKM = decimal.Parse(tbxDroveKm.Text);
            double purchaseValue = double.Parse(tbxPurchaseValue.Text);


            decimal carValueLostByKM = droveKM / 1000;
            string strCarValue = carValueLostByKM.ToString();

            // Calculate the age of the car
            DateTime localDate = DateTime.Now;
            int carAge = localDate.Year - constructionYear;

            double lostValueByAge = Math.Pow(1.2, carAge);
            double lostValueByKM = Math.Pow(0.9, double.Parse(strCarValue));

            double totalPrice = 0;

            totalPrice = purchaseValue - (lostValueByAge + lostValueByKM);
            double roundedPrice = Math.Round(totalPrice, 2);
            MessageBox.Show(roundedPrice.ToString());
            //Je zet €225,-op de bank tegen 4,5 % rente per jaar. Hoeveel heb je na 10 jaar?
            //Antwoord: €225,- × 1,045(macht)10 = €349,-



        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
