using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows;

namespace Такси.Requests
{
    public class LoginReq
    {
        
        public static bool Login(string login, string pass,int type)
        {
            bool status = false;
            string conn;
            if (type == 1)
            {
                conn = $"SELECT * FROM Водитель where Логин='{login}' and Пароль='{pass}';";
            }
            else
            {
                conn = $"SELECT * FROM Клиенты where Логин='{login}' and Пароль='{pass}';";
            }
            try
            {
                string connString = @"Data Source =.\SQLEXPRESS; Initial Catalog = Такси; integrated Security = True; ";
                //string connString = @"Data Source =localhost\SQLEXPRESS ; Initial Catalog = Такси; integrated Security = True; ";
                SqlConnection sqlConnection = new SqlConnection(connString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(conn, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {

                        status = true;

                    }
                }
                else
                {
                    MessageBox.Show("Данные не верны");
                }
                sqlCommand.Cancel();
                sqlDataReader.Close();
            }
            catch
            {
                MessageBox.Show("Error Orders");
            }
            return status;
        }

        public static int GetIdUserByLogin(string login,int level)
        {
            int status=1;
            string conn;
            if (level == 1)
            {
                conn = $"SELECT Id_водителя FROM Водитель where Логин='{login}';";
            }
            else
            {
                conn = $"SELECT Id_клиента FROM Клиенты where Логин='{login}';";
            }
            try
            {
                string connString = @"Data Source =.\SQLEXPRESS; Initial Catalog = Такси; integrated Security = True; ";
                //string connString = @"Data Source =localhost\SQLEXPRESS ; Initial Catalog = Такси; integrated Security = True; ";
                SqlConnection sqlConnection = new SqlConnection(connString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(conn, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {

                        status = Convert.ToInt32(sqlDataReader.GetValue(0));

                    }
                }
                else
                {
                    MessageBox.Show("Данные не верны ddddd");
                }
                sqlCommand.Cancel();
                sqlDataReader.Close();
            }
            catch
            {
                MessageBox.Show("Error Orders");
            }
            return status;
        }
    }
}
