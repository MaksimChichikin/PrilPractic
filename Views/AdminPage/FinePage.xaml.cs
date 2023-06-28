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
    /// Логика взаимодействия для FinePage.xaml
    /// </summary>
    public partial class FinePage : Page
    {
        private ObservableCollection<Fine> filteredFine;
        private ObservableCollection<Fine> fine;
#pragma warning disable CS8602
#pragma warning disable CS8600
#pragma warning disable CS8629
        public FinePage()
        {
            InitializeComponent();
            fine = new ObservableCollection<Fine>(
    DBConnect.userDataBase.Fines.ToList());
            filteredFine = fine;
            GridOrder.ItemsSource = filteredFine;
            GridOrder.CanUserAddRows = false;
            var maxId = DBConnect.userDataBase.Fines.Count();
            LBlOrder.Content = maxId.ToString();
        }

        private void TxbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string searchText = TxbSearch.Text.ToLower();

                if (string.IsNullOrEmpty(searchText))
                {

                    filteredFine = fine;
                }
                else
                {

                    filteredFine = new ObservableCollection<Fine>(
                        fine.Where(x =>
                            x.Id.ToString().Contains(searchText) ||
                            x.Name.ToString().ToLower().Contains(searchText) ||
                            x.FineAmount.ToString().ToLower().Contains(searchText)

                        )
                    );
                }

                GridOrder.ItemsSource = filteredFine;
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
                GridOrder.ItemsSource = new ObservableCollection<Fine>(DBConnect.userDataBase.Fines.ToList());
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
                FineWindow fineWindow = new FineWindow();
                fineWindow.ShowDialog();
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
                var row = (sender as Button)?.DataContext as Fine;
                if (row != null)
                {
                    int id = row.Id;
                    string name = row.Name;
                    decimal pecentDiscount = row.FineAmount.Value;


                    var order = DBConnect.userDataBase.Fines.FirstOrDefault(x => x.Id == id);
                    if (order != null)
                    {
                        order.Name = name;
                        order.FineAmount = pecentDiscount;

                        DBConnect.userDataBase.SaveChanges();
                        GridOrder.ItemsSource = new ObservableCollection<Fine>(DBConnect.userDataBase.Fines.ToList());
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
                MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить штраф", "Подтверждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    var row = (sender as Button)?.DataContext as Fine;
                    if (row != null)
                    {
                        DBConnect.userDataBase.Fines.Remove(row);
                        DBConnect.userDataBase.SaveChanges();
                        GridOrder.ItemsSource = new ObservableCollection<Fine>(DBConnect.userDataBase.Fines.ToList());
                        filteredFine.Remove(row);
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
