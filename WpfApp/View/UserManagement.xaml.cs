using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
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
using BusinessObjects.Models;
using Services;

namespace WpfApp.View
{
    /// <summary>
    /// Interaction logic for UserManagement.xaml
    /// </summary>
    public partial class UserManagement : UserControl
    {
        private readonly IUserService _userService;
        
        public UserManagement()
        {
            InitializeComponent();
            _userService = new UserServices();
        }

        public void LoadUserList()
        {
            try
            {
                var userList = _userService.GetAll();
                if (userList != null || userList.Count > 0)
                {
                    dgData.ItemsSource = userList;
                    dgData.Items.Refresh();
                } 
                else
                {
                    MessageBox.Show("No data found.");
                }
            } 
            catch (Exception ex) { }
            finally { ResetInput(); }
        }

        private void btnUpdateUser(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtUserId.Text.Length > 0)
                {
                    User user = new User
                    {
                        UserId = Int32.Parse(txtUserId.Text),
                        UserName = txtUserName.Text,
                        FullName = txtFullName.Text,
                        Password = txtPassword.Text,
                        RoleId = txtRoleId.Text,
                        Birthday = DateOnly.Parse(txtBirthDate.Text),
                        Address = txtAddress.Text,
                        Phone = txtPhone.Text,
                        Status = rbStatusActive.IsChecked == true ? true : false
                    };
                    
                    _userService.UpdateCustomer(user);
                }
            } 
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { LoadUserList();}
        }

        private void btnDeleteUser(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtUserId.Text.Length > 0)
                {
                    User user = new User
                    {
                        UserId = Int32.Parse(txtUserId.Text),
                        UserName = txtUserName.Text,
                        FullName = txtFullName.Text,
                        Password = txtPassword.Text,
                        RoleId = txtRoleId.Text,
                        Birthday = DateOnly.Parse(txtBirthDate.Text),
                        Address = txtAddress.Text,
                        Phone = txtPhone.Text,
                        Status = rbStatusActive.IsChecked == true ? true : false
                    };

                    _userService.DeleteCustomer(user);
                }
            } 
            catch (Exception ex) {  }
            finally { LoadUserList();}
        }

        private void btnCreateUser(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = new User();
                user.UserName = txtUserName.Text;
                user.FullName = txtFullName.Text;
                user.Password = txtPassword.Text;
                user.RoleId = txtRoleId.Text;
                user.Birthday = DateOnly.Parse(txtBirthDate.Text);
                user.Address = txtAddress.Text;
                user.Phone = txtPhone.Text;
                user.Status = rbStatusActive.IsChecked == true ? true : false;
                
                _userService.SaveUser(user);
            } 
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { LoadUserList();}
        }

        private void UserDataGrid_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGrid dataGrid = sender as DataGrid;
                DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator
                    .ContainerFromIndex(dataGrid.SelectedIndex);
                DataGridCell cell = dataGrid.Columns[0].GetCellContent(row).Parent
                    as DataGridCell;
                string id = ((TextBlock)cell.Content).Text;
                User user = _userService.GetUserById(Int32.Parse(id));
                txtUserId.Text = user.UserId.ToString();
                txtUserName.Text = user.UserName;
                txtFullName.Text = user.FullName;
                txtPassword.Text = user.Password;
                txtRoleId.Text = user.RoleId;
                txtBirthDate.Text = user.Birthday.ToString("yyyy-MM-dd");
                txtAddress.Text = user.Address;
                txtPhone.Text = user.Phone;
                rbStatusActive.IsChecked = user.Status;
                rbStatusInactive.IsChecked = !user.Status;
            }
            catch (Exception ex) {  }
        }

        private void ResetInput()
        {
            txtUserId.Text = " ";
            txtUserName.Text = " ";
            txtFullName.Text = "";
            txtPassword.Text = "";
            txtRoleId.Text = "";
            txtBirthDate.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            rbStatusActive.IsChecked = false;
            rbStatusInactive.IsChecked = false;
        }

        private void UserManagement_OnLoaded(object sender, RoutedEventArgs e)
        {
            LoadUserList();
        }
    }
}