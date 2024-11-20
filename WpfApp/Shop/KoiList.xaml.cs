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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp.Shop
{
    /// <summary>
    /// Interaction logic for KoiList.xaml
    /// </summary>
    public partial class KoiList : UserControl
    {
        private readonly KoiFishService koiFishService;
        private readonly OrderDetailService orderDetailService;
        private readonly OrderService orderService;
        private readonly ShopWindow _shopWindow;
        private Order _order;
        private int count;
        public KoiList(Order order, int cartItems, ShopWindow shopWindow)
        {
            orderService = new OrderService();
            InitializeComponent();
            koiFishService = new KoiFishService();
            orderDetailService = new OrderDetailService();
            LoadKoiFish();
            _order = order;            
            count = cartItems;
            _shopWindow = shopWindow;
        }

        private void LoadKoiFish()
        {
            using var db = new KoiFishContext();
            var category = new CategoryService();
            List<KoiFish> koiFishList = koiFishService.GetAllKoi().ToList();
            //
            foreach (var koi in koiFishList)
            {
                Border koiBorder = new Border
                {
                    BorderBrush = System.Windows.Media.Brushes.Gray,
                    BorderThickness = new Thickness(2),
                    CornerRadius = new CornerRadius(5),
                    Margin = new Thickness(10),
                    Width = 200
                };

                StackPanel koiPanel = new StackPanel
                {
                    Margin = new Thickness(10)
                };

                if (!string.IsNullOrEmpty(koi.KoiFishImage))
                {
                    string imagePath = koi.KoiFishImage;
                    Image koiImage = new Image
                    {
                        Source = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute)),
                        Width = 100,
                        Height = 150,
                        Margin = new Thickness(5)
                    };
                    koiPanel.Children.Add(koiImage);
                }
                
                koiPanel.Children.Add(new TextBlock { Text = $"ID: {koi.KoiFishId}", Margin = new Thickness(5), FontWeight = FontWeights.Bold });
                koiPanel.Children.Add(new TextBlock { Text = $"Name: {koi.KoiFishName}", Margin = new Thickness(5), FontWeight = FontWeights.Bold });
                koiPanel.Children.Add(new TextBlock { Text = $"Price: ${koi.KoiFishPrice}", Margin = new Thickness(5) });
                koiPanel.Children.Add(new TextBlock { Text = $"Origin: {koi.Origin}", Margin = new Thickness(5) });
                koiPanel.Children.Add(new TextBlock { Text = $"Weight: {koi.Weight} kg", Margin = new Thickness(5) });
                koiPanel.Children.Add(new TextBlock { Text = $"Length: {koi.Length} cm", Margin = new Thickness(5) });

                string categoryName = category.GetCategoryById(koi.CategoryId).CategoryName;
                koiPanel.Children.Add(new TextBlock { Text = $"Category: {categoryName}", Margin = new Thickness(5) });

                koiBorder.Child = koiPanel;
                //button Add to card
                Button buttonCard = new Button
                {
                    
                    Content = "Add to card",
                    //Background = Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#0099FF"),
                    Margin = new Thickness(0, 20, 0, 0),
                    Height = 30,
                    Width = 100,
                };
                buttonCard.Click += (s, e) =>
                {
                    OrderDetail orderDetail = new OrderDetail
                    {
                        KoiFishId = koi.KoiFishId,
                        OrderId = _order.OrderId,
                        Quantity = 1,
                        Price = koi.KoiFishPrice,
                        Status = true,
                    };
                    ++count;
                    _shopWindow.AddOrderDetail(orderDetail);
                    _shopWindow.UpdateCartItems(count);
                    // orderService.CreateOrder(_order, detailList);
                    //_order.OrderDetails.Add(orderDetail);
                    MessageBox.Show("Add to card successully");

                };
                koiPanel.Children.Add(buttonCard);
                //button Buy
                Button buttonBuy = new Button
                {
                    Content = "Buy",
                    //Background = Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#0099FF"),
                    Margin = new Thickness(0, 20, 0, 0),
                    Height = 30,
                    Width = 100,
                };
                buttonBuy.Click += (s, e) =>
                {
                    
                };
                koiPanel.Children.Add(buttonBuy);
                //koiBorder.MouseDown += (s, e) =>
                //{
                //    if (detailWindow == null || !detailWindow.IsVisible)
                //    {
                //        detailWindow = new DetailWindow();
                //        detailWindow.Closed += (s, args) =>
                //        {
                //            detailWindow = null;
                //            Application.Current.Shutdown();
                //        };

                //        this.Hide();
                //        detailWindow.LoadKoiFishDetails(koi);
                //        detailWindow.Show();
                //    }
                //};

                //koiBorder.MouseEnter += (s, e) => koiBorder.Background = new SolidColorBrush(Color.FromRgb(173, 216, 230));
                //koiBorder.MouseLeave += (s, e) => koiBorder.Background = null;

                DataWrapPanel.Children.Add(koiBorder);
            }
            //sau khi chọn xong thì một order được tạo lưu các orderdetail
            
        }
    }
}