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
using Services;

namespace WpfApp.Shop
{
    /// <summary>
    /// Interaction logic for CheckOut.xaml
    /// </summary>
    public partial class CheckOut : UserControl
    {
        private List<OrderDetail> _orderDetails;
        private IOrderService _orderService;
        private KoiFish _koi;
        private Order _order;
        private IKoiFishService _koiFishService;
        private IOrderDetailService _orderDetailService;
        private ShopWindow _shopWindow;
        public CheckOut(Order order, List<OrderDetail> detailList, ShopWindow shopWindow)
        {
            InitializeComponent();
            _koiFishService = new KoiFishService();
            _orderDetails = detailList;
            _order = order;
            _orderDetailService = new OrderDetailService();
            _orderService = new OrderService();
            _shopWindow = shopWindow;
        }

        private void ResetInput()
        {
            txtKoiName.Text = " ";
            txtPrice.Text = " ";
            txtQuantity.Text = "";
        }


        public void LoadOrderDetailList()
        {
            try
            {
                double sum = 0;

                foreach (OrderDetail detail in _orderDetails)
                {
                    detail.KoiFish = _koiFishService.GetKoiFishById(detail.KoiFishId);
                    sum += detail.Price ?? 0;
                }
                dgData.ItemsSource = _orderDetails;
                dgData.Items.Refresh();
                txtTotalPrice.Text = sum.ToString();
                _order.TotalMoney = sum;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on load list of orderDetail");
            }
            finally
            {
                ResetInput();
            }
        }

        private void OrderDetailManagement_OnLoaded(object sender, RoutedEventArgs e)
        {
            LoadOrderDetailList();
        }

        private void DgData_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (dgData.SelectedItem is OrderDetail detail)
                {
                    // txtOrderID.Text = detail.OrderId;
                    txtKoiName.Text = detail.KoiFish.KoiFishName.ToString();
                    txtQuantity.Text = detail.Quantity.ToString();
                    txtPrice.Text = detail.Price.ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void btnCheckout(object sender, RoutedEventArgs e)
        {
            try
            {
                _orderService.CreateOrder(_order, _orderDetails);
                MessageBox.Show("Order placed successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                _orderDetails.Clear();
                dgData.ItemsSource = null;
                _shopWindow.UpdateCartItems(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteOrder(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgData.SelectedItem is OrderDetail detail)
                {
                    var result = MessageBox.Show(
                        $"Are you sure you want to delete the order detail for '{detail.KoiFish?.KoiFishName}'?",
                        "Confirm Delete",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        _orderDetails.Remove(detail);
                        dgData.ItemsSource = null;
                        dgData.ItemsSource = _orderDetails;
                        _shopWindow.UpdateCartItems(_orderDetails.Count);
                        MessageBox.Show("Order detail deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please select an order detail to delete.", "No Selection", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                LoadOrderDetailList();
            }
        }

    }
}