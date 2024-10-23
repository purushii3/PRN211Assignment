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

namespace WpfApp.View
{
    /// <summary>
    /// Interaction logic for KoiManagement.xaml
    /// </summary>
    public partial class KoiManagement : UserControl
    {
        public KoiManagement()
        {
            InitializeComponent();
        }

        private void btnClose(object sender, RoutedEventArgs e)
        {
            AdminDashboard adminDashboard = new AdminDashboard();
            adminDashboard.Show();
        }

        private void btnCreateKoi(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdateKoi(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteKoi(object sender, RoutedEventArgs e)
        {

        }
    }
}
