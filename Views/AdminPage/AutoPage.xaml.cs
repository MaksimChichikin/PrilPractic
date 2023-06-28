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
    /// Логика взаимодействия для AutoPage.xaml
    /// </summary>
    public partial class AutoPage : Page
    {
        private ObservableCollection<Auto> filteredAuto;
        private ObservableCollection<Auto> auto;
#pragma warning disable CS8602
#pragma warning disable CS8600
#pragma warning disable CS8629
        public AutoPage()
        {
            InitializeComponent();
            auto = new ObservableCollection<Auto>(
    DBConnect.userDataBase.Autos.ToList());
            filteredAuto = auto;
            GridOrder.ItemsSource = filteredAuto;
            GridOrder.CanUserAddRows = false;
            var maxId = DBConnect.userDataBase.Autos.Count();
            LBlOrder.Content = maxId.ToString();
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string searchText = TxbSearch.Text.ToLower();

                if (string.IsNullOrEmpty(searchText))
                {

                    filteredAuto = auto;
                }
                else
                {

                    filteredAuto = new ObservableCollection<Auto>(
                        auto.Where(x =>
                            x.Id.ToString().Contains(searchText) ||
                            x.CarStateNumber.ToString().ToLower().Contains(searchText) ||
                            x.Model.ToString().ToLower().Contains(searchText) ||
                            x.Color.ToString().ToLower().Contains(searchText) ||
                            x.CarYear.ToString().Contains(searchText) ||
                            x.InsuranceValue.ToString().ToLower().Contains(searchText) ||
                            x.PricePerMinute.ToString().ToLower().Contains(searchText)
                        )
                    );
                }

                GridOrder.ItemsSource = filteredAuto;
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
                GridOrder.ItemsSource = new ObservableCollection<Auto>(DBConnect.userDataBase.Autos.ToList());
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
                AutoWindow autoWindow = new AutoWindow();
                autoWindow.ShowDialog();

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
                var row = (sender as Button)?.DataContext as Auto;
                if (row != null)
                {
                    int id = row.Id;
                    string carStateNumber = row.CarStateNumber;
                    string model= row.Model;
                    string color = row.Color;
                    int carYear = row.CarYear.Value;
                    decimal insuranceValue = row.InsuranceValue.Value;
                    decimal pricePerMinute = row.PricePerMinute.Value;

                    var order = DBConnect.userDataBase.Autos.FirstOrDefault(x => x.Id == id);
                    if (order != null)
                    {
                        order.CarStateNumber = carStateNumber;
                        order.Model = model;
                        order.Color = color;
                        order.CarYear = carYear;
                        order.InsuranceValue = insuranceValue;
                        order.PricePerMinute = pricePerMinute;
                        DBConnect.userDataBase.SaveChanges();
                        GridOrder.ItemsSource = new ObservableCollection<Auto>(DBConnect.userDataBase.Autos.ToList());
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
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить автомобиль", "Подтверждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    var row = (sender as Button)?.DataContext as Auto;
                    if (row != null)
                    {
                        DBConnect.userDataBase.Autos.Remove(row);
                        DBConnect.userDataBase.SaveChanges();
                        GridOrder.ItemsSource = new ObservableCollection<Auto>(DBConnect.userDataBase.Autos.ToList());
                        filteredAuto.Remove(row);
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
