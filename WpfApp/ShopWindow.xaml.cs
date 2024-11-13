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
        private readonly KoiFishService koiFishService;
        public ShopWindow()
        {
            InitializeComponent();
            koiFishService = new KoiFishService();
            LoadKoiFish();
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

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LoadKoiFish()
        {

            var category = new CategoryService();
            var koiFishList = koiFishService.GetAllKoi();

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
                        Source = new BitmapImage(new Uri(imagePath, UriKind.Relative)),
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}
