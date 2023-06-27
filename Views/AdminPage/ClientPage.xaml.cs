using Microsoft.EntityFrameworkCore;
using PrilPractika.ClassHelper.Global;
using PrilPractika.Models;
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
using PrilPractika.Views.AdminPage.AddPage;

namespace PrilPractika.Views.AdminPage
{
    /// <summary>
    /// Логика взаимодействия для ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Page
    {
        private ObservableCollection<Client> filteredClient;
        private ObservableCollection<Client> client;
#pragma warning disable CS8602
#pragma warning disable CS8600
        public ClientPage()
        {

            InitializeComponent();
            client = new ObservableCollection<Client>(
    DBConnect.userDataBase.Clients.Include(x => x.IdUserNavigation).ToList());
            filteredClient = client;
            GridOrder.ItemsSource = filteredClient;
            GridOrder.CanUserAddRows = false;

            var maxId = DBConnect.userDataBase.Clients.Count();
            LBlOrder.Content = maxId.ToString();

        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string searchText = TxbSearch.Text.ToLower();

                if (string.IsNullOrEmpty(searchText))
                {

                    filteredClient = client;
                }
                else
                {

                    filteredClient = new ObservableCollection<Client>(
                        client.Where(x =>
                            x.Id.ToString().Contains(searchText) ||
                            x.FullName.ToString().ToLower().Contains(searchText) ||
                            x.PassportData.ToString().ToLower().Contains(searchText) ||
                            x.DrivingLicenseData.ToString().ToLower().Contains(searchText) ||
                            x.IdUserNavigation.Login.ToString().ToLower().Contains(searchText) 
                        )
                    );
                }

                GridOrder.ItemsSource = filteredClient;
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
                GridOrder.ItemsSource = new ObservableCollection<Client>(DBConnect.userDataBase.Clients.ToList());
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
              ClientWindow   ClientWindow = new ClientWindow();
                ClientWindow.ShowDialog();

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
                var row = (sender as Button)?.DataContext as Client;
                if (row != null)
                {
                    int id = row.Id;
                    string fullName = row.FullName;
                    string passportData = row.PassportData;
                    string drivingLicenseData = row.DrivingLicenseData;

                    var order = DBConnect.userDataBase.Clients.FirstOrDefault(x => x.Id == id);
                    if (order != null)
                    {
                        order.FullName = fullName;
                        order.PassportData = passportData;
                        order.DrivingLicenseData = drivingLicenseData;
                        DBConnect.userDataBase.SaveChanges();
                        GridOrder.ItemsSource = new ObservableCollection<Client>(DBConnect.userDataBase.Clients.ToList());
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
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить клиента", "Подтверждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    var row = (sender as Button)?.DataContext as Client;
                    if (row != null)
                    {
                        DBConnect.userDataBase.Clients.Remove(row);
                        DBConnect.userDataBase.SaveChanges();
                        GridOrder.ItemsSource = new ObservableCollection<Client>(DBConnect.userDataBase.Clients.ToList());
                        filteredClient.Remove(row);
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
