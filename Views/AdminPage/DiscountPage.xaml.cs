using PrilPractika.ClassHelper.Global;
using PrilPractika.Models;
using PrilPractika.Views.AdminPage.AddPage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace PrilPractika.Views.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для DiscountPage.xaml
    /// </summary>
    public partial class DiscountPage : Page
    {
        private ObservableCollection<Discount> filteredDiscount;
        private ObservableCollection<Discount> discount;
#pragma warning disable CS8602
#pragma warning disable CS8600
#pragma warning disable CS8629
        public DiscountPage()
        {
            InitializeComponent();
            discount = new ObservableCollection<Discount>(
    DBConnect.userDataBase.Discounts.ToList());
            filteredDiscount = discount;
            GridOrder.ItemsSource = filteredDiscount;
            GridOrder.CanUserAddRows = false;
            var maxId = DBConnect.userDataBase.Discounts.Count();
            LBlOrder.Content = maxId.ToString();
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string searchText = TxbSearch.Text.ToLower();

                if (string.IsNullOrEmpty(searchText))
                {

                    filteredDiscount = discount;
                }
                else
                {

                    filteredDiscount = new ObservableCollection<Discount>(
                        discount.Where(x =>
                            x.Id.ToString().Contains(searchText) ||
                            x.Name.ToString().ToLower().Contains(searchText) ||
                            x.PercentDiscount.ToString().ToLower().Contains(searchText) 
                            
                        )
                    );
                }

                GridOrder.ItemsSource = filteredDiscount;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),
                    "Критическая ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GridOrder.ItemsSource = new ObservableCollection<Discount>(DBConnect.userDataBase.Discounts.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),
                    "Критическая ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DiscountWindow discountWindow= new DiscountWindow();
                discountWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),
                    "Критическая ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var row = (sender as Button)?.DataContext as Discount;
                if (row != null)
                {
                    int id = row.Id;
                    string name = row.Name;
                    decimal pecentDiscount = row.PercentDiscount.Value;
                    

                    var order = DBConnect.userDataBase.Discounts.FirstOrDefault(x => x.Id == id);
                    if (order != null)
                    {
                        order.Name = name;
                        order.PercentDiscount = pecentDiscount;
                        
                        DBConnect.userDataBase.SaveChanges();
                        GridOrder.ItemsSource = new ObservableCollection<Discount>(DBConnect.userDataBase.Discounts.ToList());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),
                    "Критическая ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить скидку", "Подтверждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    var row = (sender as Button)?.DataContext as Discount;
                    if (row != null)
                    {
                        DBConnect.userDataBase.Discounts.Remove(row);
                        DBConnect.userDataBase.SaveChanges();
                        GridOrder.ItemsSource = new ObservableCollection<Discount>(DBConnect.userDataBase.Discounts.ToList());
                        filteredDiscount.Remove(row);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),
                    "Критическая ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }
    }
}
