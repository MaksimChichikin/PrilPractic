using PrilPractika.ClassHelper.Global;
using PrilPractika.Models;
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

namespace PrilPractika.Views.AdminPage.AddPage
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public ClientWindow()
        {
            InitializeComponent();
            CmbUser.DisplayMemberPath = "Login";
            CmbUser.SelectedValuePath = "Id";
            CmbUser.ItemsSource = DBConnect.userDataBase.Users.ToList();
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client client = new Client()
                {
                    FullName = TxbFullName.Text,
                    PassportData = TxbPassport.Text,
                    DrivingLicenseData =TxbPassportAuto.Text,
                    IdUserNavigation = CmbUser.SelectedItem as User

                };

                DBConnect.userDataBase.Clients.Add(client);
                DBConnect.userDataBase.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!",
                "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                Window.GetWindow(this).Close();
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
