using PrilPractika.ClassHelper.Global;
using PrilPractika.Views.AdminPage;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PrilPractika
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += DispacherTimer_Tick;
            dispatcherTimer.Start();
            NavigationClass.frmNav = FrmMain;
            FrmMain.Navigate(new ClientPage());
        }
        private void DispacherTimer_Tick(object? sender, EventArgs e)
        {
            TxbBlkTimeNow.Text = DateTime.Now.ToString("HH:mm");
            TxbBlkDateTime.Text = DateTime.Now.ToString("d");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.frmNav?.Navigate(new ClientPage());
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.frmNav?.Navigate(new AutoPage());
        }

        private void BtnCompany_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.frmNav?.Navigate(new DiscountPage());
        }

        private void BtnTask_Click(object sender, RoutedEventArgs e)
        {
            NavigationClass.frmNav?.Navigate(new FinePage());
        }
    }
}
