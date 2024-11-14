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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp.Shop
{
    /// <summary>
    /// Interaction logic for CheckOut.xaml
    /// </summary>
    public partial class CheckOut : UserControl
    {
        public CheckOut()
        {
            InitializeComponent();
        }

        private void btnCheckout(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdateOrder(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteOrder(object sender, RoutedEventArgs e)
        {

        }

        private void btnIncrease_OnClick(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtQuantity.Text, out int quantity))
            {
                txtQuantity.Text = (quantity + 1).ToString();
            }
            else
            {
                MessageBox.Show("Invalid quantity! Please enter a valid number.");
                txtQuantity.Text = "1"; 
            }
        }

        private void btnReduce_OnClick(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtQuantity.Text, out int quantity))
            {
                if (quantity > 1) 
                {
                    txtQuantity.Text = (quantity - 1).ToString();
                }
            }
            else
            {
                MessageBox.Show("Invalid quantity! Please enter a valid number.");
                txtQuantity.Text = "1";
            }
        }
    }
}
