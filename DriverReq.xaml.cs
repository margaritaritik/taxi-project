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
using Такси.Requests;

namespace Такси
{
    /// <summary>
    /// Логика взаимодействия для DriverReq.xaml
    /// </summary>
    public partial class DriverReq : Window
    {
        public DriverReq()
        {
            InitializeComponent();
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            ReginReq.RegistrationDriver(fullname.Text, phone.Text, login.Text, pass.Text, 1, CarsReq.GetCarId());
            MainClientWin mainClientWindow = new MainClientWin(LoginReq.GetIdUserByLogin(login.Text, 1),1);
            mainClientWindow.Show();
            this.Close();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
