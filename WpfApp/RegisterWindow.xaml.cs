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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private readonly IUserService _userService;
        public RegisterWindow()
        {
            InitializeComponent();
            _userService = new UserServices();
        }
        private void txtFullname_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPlaceholderN.Visibility = Visibility.Collapsed;
        }
        private void txtFullname_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFullname.Text))
            {
                txtPlaceholderN.Visibility = Visibility.Visible; 
            }
        }

        private void txtPhone_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPlaceholderPhone.Visibility = Visibility.Collapsed;
        }
        private void txtPhone_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                txtPlaceholderPhone.Visibility = Visibility.Visible; 
            }
        }

        private void txtBirthday_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPlaceholderB.Visibility = Visibility.Collapsed; 
        }
        private void txtBirthday_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBirthday.Text))
            {
                txtPlaceholderB.Visibility = Visibility.Visible; 
            }
        }

        private void txtA_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPlaceholderA.Visibility = Visibility.Collapsed;
        }
        private void txtA_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBirthday.Text))
            {
                txtPlaceholderA.Visibility = Visibility.Visible;
            }
        }

        private void txtUser_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPlaceholder.Visibility = Visibility.Collapsed; 
        }
        private void txtUser_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                txtPlaceholder.Visibility = Visibility.Visible; 
            }
        }

        private void txtPass_GotFocus(object sender, RoutedEventArgs e)
        {          
            txtPlaceholderP.Visibility = Visibility.Collapsed;
        }
        private void txtPass_LostFocus(object sender, RoutedEventArgs e)
        {           
            if (string.IsNullOrEmpty(txtPass.Password))
            {
                txtPlaceholderP.Visibility = Visibility.Visible;
            }
        }

        private void txtPassC_GotFocus(object sender, RoutedEventArgs e)
        {
            txtPlaceholderPC.Visibility = Visibility.Collapsed;
        }
        private void txtPassC_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPass.Password))
            {
                txtPlaceholderPC.Visibility = Visibility.Visible;
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            bool isRegistered = false;
            try
            {
                User customer = new User();
                // List<User> users = _userService.GetAll();
                // int id = (users.Count > 0) ? users.Max(x => x.UserId) : 0;
                // customer.UserId = ++id;
                customer.FullName = txtFullname.Text;
                customer.Phone = txtPhone.Text;
                //email
                if (!string.IsNullOrWhiteSpace(txtUser.Text))
                {
                    customer.UserName = txtUser.Text;

                }
                else
                {
                    MessageBox.Show("Username cannot be empty.");
                    return;
                }
                //birthday
                if (DateOnly.TryParseExact(txtBirthday.Text, "yyyy-MM-dd", out DateOnly birthday) ||
                    DateOnly.TryParseExact(txtBirthday.Text, "dd/MM/yyyy", out birthday))
                {
                    customer.Birthday = birthday;
                }
                else
                {
                    MessageBox.Show("Please enter your date of birth in yyyy-MM-dd or dd/MM/yyyy format.");
                    return;
                }
                if(txtPass.Password == txtPassC.Password)
                {
                    customer.Password = txtPass.Password;
                }
                else
                {
                    MessageBox.Show("Password does not match, please re-enter!");
                    return;
                }
                customer.Address = txtAddress.Text;
                customer.Status = true;                
                customer.RoleId = "US";
                _userService.SaveUser(customer);
                isRegistered = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error RegisterWindow: {ex.Message}\n{ex.StackTrace}");
            }
            if (isRegistered)
            {
                MessageBox.Show("Registered successfully!");
                this.Hide();
                LoginWindow l = new LoginWindow();
                l.Show();
            }
        }
    }
}
