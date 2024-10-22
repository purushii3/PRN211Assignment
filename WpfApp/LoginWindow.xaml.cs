using BusinessObjects.Models;
using Services;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IUserService _userService;
        public LoginWindow()
        {
            InitializeComponent();
            _userService = new UserServices();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            User user = _userService.GetUserByUserName(txtUser.Text);
            if (user != null && user.Password.Equals(txtPass.Password)) 
            {
                if (user.RoleId.Equals("AD"))
                {
                    this.Hide();
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                }
                else if (user.RoleId.Equals("US"))
                {
                    this.Hide();
                    ShopWindow shopWindow = new ShopWindow();
                    shopWindow.Show();
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect!!!");
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
