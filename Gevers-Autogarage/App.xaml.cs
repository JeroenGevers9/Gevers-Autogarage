using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Gevers_Autogarage
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void InitializeApp(object sender, StartupEventArgs e)
        {
            // Initialze application
            MainWindow mainWindow = new MainWindow();

            if (Classes.DbClass.EstablishConnection())
            {
                mainWindow.Show();
            }
            else
            {
                MessageBox.Show("Er is geen connectie met de database mogelijk. Check de server uw server werkt.");
            }
        }
    }
}
