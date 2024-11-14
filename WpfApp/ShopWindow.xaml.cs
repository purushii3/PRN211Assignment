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
using System.Collections.ObjectModel;
using Services;
using BusinessObjects.Models;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for ShopWindow.xaml
    /// </summary>
    public partial class ShopWindow : Window
    {
        private readonly UserServices _userServices;
        private readonly string _userName;
        public ShopWindow(string userName)
        {
            InitializeComponent();
            _userServices = new UserServices();
            _userName = userName;
            Login.Content = $"Hello, {_userName}";
            ContentArea.Content = new Shop.KoiList();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private bool IsMaximize = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximize)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1250;
                    this.Height = 830;

                    IsMaximize = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;

                    IsMaximize = true;
                }
            }
        }

        private void koiList_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new Shop.KoiList();
        }
        
        private void btnShoppingClick(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new Shop.CheckOut();
        }
        
        private void logOut_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            this.Close();
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            Close();
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }


        
    }

}
