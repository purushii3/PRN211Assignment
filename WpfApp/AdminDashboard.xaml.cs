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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for AdminDashboard.xaml
    /// </summary>
    public partial class AdminDashboard : Window
    {
        public AdminDashboard()
        {
            InitializeComponent();
            AdminName.Text = "NameTest";
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
    }
}
