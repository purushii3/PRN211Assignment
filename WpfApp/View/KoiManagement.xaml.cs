﻿using System;
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
using BusinessObjects.Models;
using Services;

namespace WpfApp.View
{
    /// <summary>
    /// Interaction logic for KoiManagement.xaml
    /// </summary>
    public partial class KoiManagement : UserControl
    {
        private readonly IKoiFishService _koiFishService;
        private readonly ICategoryService _categoryService;
        
        public KoiManagement()
        {
            InitializeComponent();
            _koiFishService = new KoiFishService();
            _categoryService = new CategoryService();
        }

        public void LoadKoiCategory()
        {
            var catList = _categoryService.GetCategories();
            cboCategory.ItemsSource = catList;
            cboCategory.DisplayMemberPath = "CategoryName";
            cboCategory.SelectedValuePath = "CategoryId";
        }

        public void LoadKoiList()
        {
            try
            {
                var koiList = _koiFishService.GetAllKoi();
                dgData.ItemsSource = koiList;
                dgData.Items.Refresh();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { ResetInput(); }
        }

        private void btnCreateKoi(object sender, RoutedEventArgs e)
        {
            try
            {
                KoiFish koiFish = new KoiFish
                {
                    KoiFishName = KoiName.Text,
                    KoiFishImage = Image.Text,
                    KoiFishQuantity = Int32.Parse(Quantity.Text),
                    KoiFishPrice = Double.Parse(Price.Text),
                    Origin = Origin.Text,
                    HealthStatus = Int32.Parse(HealthStatus.Text),
                    AwardCertificate = Certificate.Text,
                    Weight = Double.Parse(Weight.Text),
                    Length = Double.Parse(Length.Text),
                    Status = rbStatusActive.IsChecked == true ? true : false,
                    CategoryId = Int32.Parse(cboCategory.SelectedValue.ToString())
                };
                
                _koiFishService.SaveKoi(koiFish);
                
            } 
            catch (Exception ex) {  }
            finally { LoadKoiList();}
        }

        private void btnUpdateKoi(object sender, RoutedEventArgs e)
        {
            try
            {
                if (KoiId.Text.Length > 0)
                {
                    KoiFish koiFish = new KoiFish
                    {
                        KoiFishId = Int32.Parse(KoiId.Text),
                        KoiFishName = KoiName.Text,
                        KoiFishImage = Image.Text,
                        KoiFishQuantity = Int32.Parse(Quantity.Text),
                        KoiFishPrice = Double.Parse(Price.Text),
                        Origin = Origin.Text,
                        HealthStatus = Int32.Parse(HealthStatus.Text),
                        AwardCertificate = Certificate.Text,
                        Weight = Double.Parse(Weight.Text),
                        Length = Double.Parse(Length.Text),
                        Status = rbStatusActive.IsChecked == true ? true : false,
                        CategoryId = Int32.Parse(cboCategory.SelectedValue.ToString())
                    };
                    
                    _koiFishService.UpdateKoiFish(koiFish);
                }
            } 
            catch (Exception ex) { }
            finally { LoadKoiList();}
        }

        private void btnDeleteKoi(object sender, RoutedEventArgs e)
        {
            try
            {
                if (KoiId.Text.Length > 0)
                {
                    KoiFish koiFish = new KoiFish
                    {
                        KoiFishId = Int32.Parse(KoiId.Text),
                        KoiFishName = KoiName.Text,
                        KoiFishImage = Image.Text,
                        KoiFishQuantity = Int32.Parse(Quantity.Text),
                        KoiFishPrice = Double.Parse(Price.Text),
                        Origin = Origin.Text,
                        HealthStatus = Int32.Parse(HealthStatus.Text),
                        AwardCertificate = Certificate.Text,
                        Weight = Double.Parse(Weight.Text),
                        Length = Double.Parse(Length.Text),
                        Status = rbStatusActive.IsChecked == true ? true : false,
                        CategoryId = Int32.Parse(cboCategory.SelectedValue.ToString())
                    };
                    
                    _koiFishService.DeleteKoiFish(koiFish);
                }
            } 
            catch (Exception ex) {  }
            finally { LoadKoiList();}
        }

        private void KoiManagement_OnLoaded(object sender, RoutedEventArgs e)
        {
            LoadKoiCategory();
            LoadKoiList();
        }

        private void ResetInput()
        {
            KoiId.Text = " ";
            KoiName.Text = " ";
            Image.Text = " ";
            Quantity.Text = " ";
            Price.Text = " ";
            Origin.Text = " ";
            HealthStatus.Text = " ";
            Certificate.Text = " ";
            Weight.Text = " ";
            Length.Text = " ";
            rbStatusActive.IsChecked = false;
            rbStatusInactive.IsChecked = false;
            cboCategory.SelectedValue = 0;
        }

        private void DgData_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row = (DataGridRow)dataGrid.ItemContainerGenerator
                .ContainerFromIndex(dataGrid.SelectedIndex);
            
            DataGridCell cell = dataGrid.Columns[0].GetCellContent(row).Parent
                as DataGridCell;
            string id = ((TextBlock)cell.Content).Text;
            KoiFish koiFish = _koiFishService.GetKoiFishById(Int32.Parse(id));
            KoiId.Text = koiFish.KoiFishId.ToString();
            KoiName.Text = koiFish.KoiFishName;
            Image.Text = koiFish.KoiFishImage;
            Quantity.Text = koiFish.KoiFishQuantity.ToString();
            Price.Text = koiFish.KoiFishPrice.ToString();
            Origin.Text = koiFish.Origin;
            HealthStatus.Text = koiFish.HealthStatus.ToString();
            Certificate.Text = koiFish.AwardCertificate;
            Weight.Text = koiFish.Weight.ToString();
            Length.Text = koiFish.Length.ToString();
            rbStatusActive.IsChecked = koiFish.Status;
            rbStatusInactive.IsChecked = !koiFish.Status;
            cboCategory.SelectedValue = koiFish.CategoryId;

        }
    }
}