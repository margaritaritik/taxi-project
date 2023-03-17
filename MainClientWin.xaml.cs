using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Такси.Models;
using Такси.Requests;

namespace Такси
{
    /// <summary>
    /// Логика взаимодействия для MainClientWin.xaml
    /// </summary>
    public partial class MainClientWin : Window
    {
        int level = 1;
        public int flagPagin = 0;
    
        public MainClientWin(int id,int who)
        {
            InitializeComponent();
            level = who;
            menu.ItemsSource = ClientOrders.GetAllOrdersUser(id);
            products.ItemsSource = ClientOrders.GetAllOrders();
            if (level == 1)
            {
                ClientOrDriver.Content = "Водитель";
                OrdersTab.Visibility = Visibility.Hidden;
            }
            else
            {
                ClientOrDriver.Content = "Клиент";
                DriversTab.Visibility = Visibility.Hidden;

            }
        }


        private void exitbtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
