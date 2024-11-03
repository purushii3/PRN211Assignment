using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Services;
using MessageBox = System.Windows.MessageBox;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for AdminDashboard.xaml
    /// </summary>
    public partial class AdminDashboard : Window
    {
        private readonly IUserService _userService;
        private readonly string _adminName;
        public AdminDashboard(string adminName)
        {
            InitializeComponent();
            _userService = new UserServices();
            _adminName = adminName;
            AdminName.Text = _adminName;
        }

        private void CategoryList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoryList.SelectedItem is ListBoxItem selectedItem)
            {
                switch (selectedItem.Content.ToString())
                {
                    case "Koi Management":
                        ContentArea.Content = new View.KoiManagement();
                        break;

                    case "User Management":
                        ContentArea.Content = new View.UserManagement();
                        break;
                }
            }
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}