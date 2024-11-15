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
using BusinessObjects.Models;

namespace WpfApp.Shop
{
    /// <summary>
    /// Interaction logic for CheckOut.xaml
    /// </summary>
    public partial class CheckOut : UserControl
    {
        private List<OrderDetail> _orderDetails;
        private Order _order;
        public CheckOut(Order order, List<OrderDetail> detailList)
        {
            InitializeComponent();
            _orderDetails = detailList;
            _order = order;
        }


        private void DgData_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnCheckout(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnDeleteOrder(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
