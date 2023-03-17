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
    /// Логика взаимодействия для LoginClient.xaml
    /// </summary>
    public partial class LoginClient : Window
    {
        int level = 1;
        public LoginClient(int type)
        {
            InitializeComponent();
            level = type;
            if (level == 1)
            {
                NameLogin.Content = "Авторизация водителя";
            }
            else
            {
                NameLogin.Content = "Авторизация пользователя";
            }

        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            if (LoginReq.Login(login.Text, pass.Text, level) == true)
            {
                MainClientWin view = new MainClientWin(LoginReq.GetIdUserByLogin(login.Text,level), level);
                view.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!!!");
            }  
                
 
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
