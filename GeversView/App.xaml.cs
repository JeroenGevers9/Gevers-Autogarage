using GeversView;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace GeversView
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void InitializeApp(object sender, StartupEventArgs e)
        {
            // Do something before start
            MainWindow mw = new MainWindow();
            mw.Show();
        }
    }
}
