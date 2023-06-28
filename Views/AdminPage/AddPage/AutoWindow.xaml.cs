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
    /// Логика взаимодействия для AutoWindow.xaml
    /// </summary>
    public partial class AutoWindow : Window
    {
        public AutoWindow()
        {
            InitializeComponent();
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Auto auto = new Auto()
                {
                    CarStateNumber = TxbCarStateNumber.Text,
                    Model = TxbModel.Text,
                    Color = TxbColor.Text,
                    CarYear = int.Parse(TxbCarYear.Text),
                    InsuranceValue = decimal.Parse(TxbInsuranceValue.Text),
                    PricePerMinute = decimal.Parse(TxbPricePerMinute.Text)


                };

                DBConnect.userDataBase.Autos.Add(auto);
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
