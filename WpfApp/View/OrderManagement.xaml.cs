using System.Windows;
using System.Windows.Controls;
using BusinessObjects.Models;
using Services;
using MessageBox = System.Windows.Forms.MessageBox;

namespace WpfApp.View;

public partial class OrderManagement : UserControl
{
    private readonly IOrderService _orderService;
    private readonly IUserService _userService;
    
    
    public OrderManagement()
    {
        InitializeComponent();
        _orderService = new OrderService();
        _userService = new UserServices();
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
        LoadOrders();
    }

    private void btnCreateOrder(object sender, RoutedEventArgs e)
    {
        try
        {
            Order order = new Order
            {
                Date = DateOnly.Parse(txtDate.Text),
                UserId = Int32.Parse(txtUserId.Text),
                ServiceId = Int32.Parse(txtServiceId.Text),
                TotalMoney = Double.Parse(txtTotalMoney.Text),
                Status = rbStatusActive.IsChecked == true ? true : false,
            };

            OrderDetail orderDetail = new OrderDetail()
            {
                OrderId = order.OrderId,

            };
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
        finally { LoadOrders(); }
    }

    private void btnUpdateOrder(object sender, RoutedEventArgs e)
    {
        try
        {
            
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
        finally { LoadOrders(); }
    }

    private void btnDeleteOrder(object sender, RoutedEventArgs e)
    {
        try
        {
            
        }
        catch (Exception ex) { MessageBox.Show(ex.Message); }
        finally { LoadOrders(); }
    }

    private void DgData_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        DataGrid dataGrid = sender as DataGrid;
        DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator
            .ContainerFromIndex(dataGrid.SelectedIndex);
        DataGridCell cell = dataGrid.Columns[0].GetCellContent(row).Parent
            as DataGridCell;
        string id = ((TextBlock)cell.Content).Text;
        Order order = _orderService.GetOrderById(id);
        txtOrderId.Text = id;
        txtDate.Text = order.Date.ToString("dd/MM/yyyy");
        txtUserId.Text = order.UserId.ToString();
        txtServiceId.Text = order.ServiceId.ToString();
        txtTotalMoney.Text = order.TotalMoney.ToString();
        rbStatusActive.IsChecked = order.Status;
        rbStatusInactive.IsChecked = order.Status;
    }

    public void ResetInput()
    {
        txtOrderId.Text = "";
        txtDate.Text = "";
        txtUserId.Text = "";
        txtServiceId.Text = "";
        txtTotalMoney.Text = "";
        rbStatusActive.IsChecked = false;
        rbStatusInactive.IsChecked = false;
    }
}