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
using GeversLogic;

namespace GeversView
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private Company _company;
        private IUserStorage userStorage;
        public Login(Company company, IUserStorage _userStorage)
        {
            InitializeComponent();
            _company = company;
            userStorage = _userStorage;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            User user = new User(userStorage);
            User loggedInUser = user.CheckExist(tbxUsername.Text, pwbPassword.Password);
            if (loggedInUser != null)
            {
                user.Username = tbxUsername.Text;
                MessageBox.Show("Welkom " + tbxUsername.Text);
                MainWindow mw = new MainWindow(loggedInUser);
                mw.Show();
                this.Close();
            }
            else
            {
                tbxUsername.Text = "";
                pwbPassword.Password = "";
                MessageBox.Show("Invalid Username or Password combination, please try again.");
            }
        }
    }
}
