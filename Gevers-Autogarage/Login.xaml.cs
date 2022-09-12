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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            Classes.DbClass.EstablishConnection();

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string sessionData = Classes.DbClass.Login(tbxUsername.Text, pwbPassword.Password);
            if (sessionData != "")
            {
                Classes.Session.LoggedIn = true;
                Classes.Session.Username = tbxUsername.Text;
                var mw = new MainWindow();
                mw.Show();
                this.Hide();
            }
            else
            {
                tbxUsername.Text = "";
                pwbPassword.Password = "";
                MessageBox.Show("Invalid Username or Password (combination, please try again.");
            }
        }
    }
}
