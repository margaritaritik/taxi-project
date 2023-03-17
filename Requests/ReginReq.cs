using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Такси.Requests
{
    public class ReginReq
    {
        public static void Registration(string fullname, string phone, string login, string pass, int level)
        {
            try
            {
                 string connString = @"Data Source =.\SQLEXPRESS; Initial Catalog = Такси; integrated Security = True; ";
                //string connString = @"Data Source =localhost\SQLEXPRESS ; Initial Catalog = Такси; integrated Security = True; ";
                SqlConnection sqlConnection = new SqlConnection(connString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"insert into Клиенты(ФИО, Телефон, Логин, Пароль, Id_уровня) values('{fullname}', '{phone}', '{login}','{pass}',{level})", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Cancel();
                sqlConnection.Close();
                MessageBox.Show("Пользователь добавлен");
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        public static void RegistrationDriver(string fullname, string phone, string login, string pass, int level,int id_car)
        {
            try
            {
                string connString = @"Data Source =.\SQLEXPRESS; Initial Catalog = Такси; integrated Security = True; ";
                //string connString = @"Data Source =localhost\SQLEXPRESS ; Initial Catalog = Такси; integrated Security = True; ";
                SqlConnection sqlConnection = new SqlConnection(connString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"insert into Водитель(ФИО, Телефон, Логин, Пароль, Id_уровня, Id_авто) values('{fullname}', '{phone}', '{login}','{pass}',{level},{id_car})", sqlConnection);
                sqlCommand.ExecuteNonQuery();
                sqlCommand.Cancel();
                sqlConnection.Close();
                MessageBox.Show("Пользователь добавлен");
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }
    }
}
