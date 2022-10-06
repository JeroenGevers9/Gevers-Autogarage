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
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Classes.User user = Classes.DbClass.Login(tbxUsername.Text, pwbPassword.Password);
            
            if (user.Username != "")
            {
                MessageBox.Show("Welkom " + user.Username);
                var mw = new MainWindow();
                mw.Show();
                this.Close();
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
