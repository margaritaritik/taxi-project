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
    /// Логика взаимодействия для ClientReg.xaml
    /// </summary>
    public partial class ClientReg : Window
    {
        public ClientReg()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            ReginReq.Registration(fullname.Text, phone.Text, login.Text, pass.Text, 2);
            MainClientWin mainClientWindow = new MainClientWin(LoginReq.GetIdUserByLogin(login.Text, 2),2);
            mainClientWindow.Show();
            this.Close();
        }

        private void auth_Click(object sender, RoutedEventArgs e)
        {
            LoginClient mainWindow = new LoginClient(2);
            mainWindow.Show();
            this.Close();
        }
    }
}
