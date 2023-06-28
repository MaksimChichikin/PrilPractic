﻿using PrilPractika.ClassHelper.Global;
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
    /// Логика взаимодействия для DiscountWindow.xaml
    /// </summary>
    public partial class DiscountWindow : Window
    {
        public DiscountWindow()
        {
            InitializeComponent();
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Discount discount = new Discount()
                {
                    Name = TxbDiscount.Text,
                    PercentDiscount = decimal.Parse(TxbPrice.Text)
                    

                };

                DBConnect.userDataBase.Discounts.Add(discount);
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
