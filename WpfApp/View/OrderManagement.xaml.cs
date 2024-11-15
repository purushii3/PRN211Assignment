using System.Runtime.InteropServices.JavaScript;
using System.Windows;
using System.Windows.Controls;
using BusinessObjects.Models;
using Services;

namespace WpfApp.View;

public partial class OrderManagement : UserControl
{
    private readonly IOrderService _orderService;
    private readonly IUserService _userService;
    private readonly IKoiFishService _koiFishService;
    private readonly IOrderDetailService _orderDetailService;
    
    
    public OrderManagement()
    {
        InitializeComponent();
        _orderService = new OrderService();
        _userService = new UserServices();
        _koiFishService = new KoiFishService();
        _orderDetailService = new OrderDetailService();
    }

    public void LoadKoiFish()
    {
        var koi = _koiFishService.GetAllKoi();
        cboKoi.ItemsSource = koi;
        cboKoi.DisplayMemberPath = "KoiFishName";
        cboKoi.SelectedValuePath = "KoiFishId";
        
    }

    public void LoadUsers()
    {
        try
        {
            var users = _userService.GetAll();
            cboUser.ItemsSource = users;
            cboUser.DisplayMemberPath = "UserName";
            cboUser.SelectedValuePath = "UserId";
        }
        catch (Exception ex) {}
        
    }

    public void LoadOrders()
    {
        try
        {
            var orders = _orderService.GetAllOrders();
            dgData.ItemsSource = orders;
            dgData.Items.Refresh();
        }
        catch (Exception ex) {}
        finally{ ResetInput(); }
    }

    private void OrderManagement_OnLoaded(object sender, RoutedEventArgs e)
    {
        LoadKoiFish();
        LoadUsers();
        LoadOrders();
    }

    private void btnCreateOrder(object sender, RoutedEventArgs e)
    {
        try
        {
            Order order = new Order
            {
                OrderId = Guid.NewGuid().ToString(),
                Date = DateOnly.Parse(txtDate.Text),
                UserId = Int32.Parse(cboUser.SelectedValue.ToString() ?? string.Empty),
                ServiceId = 1,
                TotalMoney = Double.Parse(txtTotalMoney.Text),
                Status = rbStatusActive.IsChecked == true ? true : false,
            };

            List<OrderDetail> detailList = new List<OrderDetail>();
            OrderDetail orderDetail = new OrderDetail()
            {
                OrderId = order.OrderId,
                KoiFishId = Int32.Parse(cboKoi.SelectedValue.ToString() ?? string.Empty),
                Quantity = Int32.Parse(txtQuantity.Text),
                Price = Int32.Parse(txtPrice.Text),
                Status = rbStatusOn.IsChecked == true ? true : false,
            };
            
            detailList.Add(orderDetail);
            _orderService.CreateOrder(order, detailList);
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
        finally { LoadOrders(); }
    }

    private void btnUpdateOrder(object sender, RoutedEventArgs e)
    {
        // try
        // {
        //     string orderId = txtOrderId.Text;
        //     var existingOrder = _orderService.GetOrderById(orderId);
        //     List<OrderDetail> orderDetail = _orderDetailService.GetOrderDetails(orderId);
        //     
        //     
        //
        // }
        // catch (Exception ex) { MessageBox.Show(ex.Message); }
        // finally { LoadOrders(); }
    }

    private void btnDeleteOrder(object sender, RoutedEventArgs e)
    {
        try
        {
            var result = MessageBox.Show("Do you really want to delete this order?", 
                "Delete Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);
            
            if (result == MessageBoxResult.Yes)
            {
                Order order = new Order
                {
                    OrderId = txtOrderId.Text,
                    Date = DateOnly.Parse(txtDate.Text),
                    TotalMoney = Int32.Parse(txtTotalMoney.Text),
                    Status = rbStatusActive.IsChecked == true ? true : false,
                };

                OrderDetail detail = new OrderDetail
                {
                    OrderId = order.OrderId,
                    KoiFishId = Int32.Parse(cboKoi.SelectedValue.ToString() ?? string.Empty),
                    Quantity = Int32.Parse(txtQuantity.Text),
                    Price = Double.Parse(txtPrice.Text),
                    Status = rbStatusActive.IsChecked == true,
                };
                
                _orderService.DeleteOrder(order.OrderId);
                // _orderDetailService.DeleteOrderDetail(detail);
                
                MessageBox.Show("Booking deleted successfully!");
            }
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
        finally { LoadOrders(); }
    }
    
    private void btnDeleteOrderDetail(object sender, RoutedEventArgs e)
    {
        try
        {
            var result = MessageBox.Show("Do you really want to delete this order detail?", 
                "Delete Confirmation",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                Order order = new Order
                {
                    OrderId = txtOrderId.Text,
                    Date = DateOnly.Parse(txtDate.Text),
                    TotalMoney = Int32.Parse(txtTotalMoney.Text),
                    Status = rbStatusActive.IsChecked == true ? true : false,
                };

                OrderDetail detail = new OrderDetail
                {
                    OrderId = order.OrderId,
                    KoiFishId = Int32.Parse(cboKoi.SelectedValue.ToString() ?? string.Empty),
                    Quantity = Int32.Parse(txtQuantity.Text),
                    Price = Double.Parse(txtPrice.Text),
                    Status = rbStatusActive.IsChecked == true,
                };

                // _orderService.DeleteOrder(order.OrderId);
                _orderDetailService.DeleteOrderDetail(detail);

                MessageBox.Show("Order detail deleted successfully!");
            }

        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
        finally { LoadOrders(); }
    }

    private void DgData_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // order
        
        DataGrid dataGrid = sender as DataGrid;
        DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator
            .ContainerFromIndex(dataGrid.SelectedIndex);
        DataGridCell cell = dataGrid.Columns[0].GetCellContent(row).Parent
            as DataGridCell;
        string id = ((TextBlock)cell.Content).Text;
        Order order = _orderService.GetOrderById(id);
        txtOrderId.Text = id;
        txtDate.Text = order.Date.ToString("dd/MM/yyyy");
        cboUser.SelectedValue = order.UserId;
        txtTotalMoney.Text = order.TotalMoney.ToString();
        rbStatusActive.IsChecked = order.Status;
        rbStatusInactive.IsChecked = !order.Status;
        
        // order detail

        var orderDetail = _orderDetailService.GetOrderDetails(order.OrderId);
        var detailList = orderDetail.FirstOrDefault();
        
        cboKoi.SelectedValue = detailList.KoiFishId.ToString();
        txtQuantity.Text = detailList.Quantity.ToString();
        txtPrice.Text = detailList.Price.ToString();
        
        dgDetails.ItemsSource = orderDetail;
        dgDetails.Items.Refresh();

    } 

    public void ResetInput()
    {
        txtOrderId.Text = "";
        txtDate.Text = "";
        cboUser.SelectedValue = 0;
        txtTotalMoney.Text = "";
        rbStatusActive.IsChecked = false;
        rbStatusInactive.IsChecked = false;
    }

    private void DgDetails_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            if (dgDetails.SelectedItem is OrderDetail detail)
            {
                // txtOrderID.Text = detail.OrderId;
                cboKoi.SelectedValue = detail.KoiFishId.ToString();
                txtQuantity.Text = detail.Quantity.ToString();
                txtPrice.Text = detail.Price.ToString();
                rbStatusOn.IsChecked = detail.Status;
                rbStatusOff.IsChecked = !detail.Status;
            }
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
    }

    
}