using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using Такси.Models;

namespace Такси.Requests
{
    public class ClientOrders
    {
        public static List<OrderTab> GetAllOrders()
        {
            List<OrderTab> orders = new List<OrderTab>();
            try
            {
                string connString = @"Data Source =.\SQLEXPRESS; Initial Catalog = Такси; integrated Security = True; ";
                //string connString = @"Data Source =localhost\SQLEXPRESS ; Initial Catalog = Такси; integrated Security = True; ";
                SqlConnection sqlConnection = new SqlConnection(connString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"SELECT Заказ.Id_заказа, Клиенты.ФИО,Клиенты.Телефон, Точки.Адрес FROM Заказ,Клиенты,Точки where Заказ.Id_клиента=Клиенты.Id_клиента and Точки.Id_заказа=Заказ.Id_заказа; ", sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        orders.Add(new OrderTab()
                        {
                            Id = Convert.ToInt32(sqlDataReader.GetValue(0)),
                            ClientName = (sqlDataReader.GetValue(1)).ToString(),
                            Phone= (sqlDataReader.GetValue(2)).ToString(),
                            ToWhere = (sqlDataReader.GetValue(3)).ToString(),
                        });
                   
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
            return orders;
        }

        public static List<OrderTab> GetAllOrdersUser(int id)
        {
            List<OrderTab> orders = new List<OrderTab>();
            try
            {
                string connString = @"Data Source =.\SQLEXPRESS; Initial Catalog = Такси; integrated Security = True; ";
                //string connString = @"Data Source =localhost\SQLEXPRESS ; Initial Catalog = Такси; integrated Security = True; ";
                SqlConnection sqlConnection = new SqlConnection(connString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"SELECT Заказ.Id_заказа, Клиенты.ФИО,Клиенты.Телефон, Точки.Адрес FROM Заказ,Клиенты,Точки where Заказ.Id_клиента=Клиенты.Id_клиента and Точки.Id_заказа=Заказ.Id_заказа and Заказ.Id_клиента={id}; ", sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        orders.Add(new OrderTab()
                        {
                            Id = Convert.ToInt32(sqlDataReader.GetValue(0)),
                            ClientName = (sqlDataReader.GetValue(1)).ToString(),
                            Phone = (sqlDataReader.GetValue(2)).ToString(),
                            ToWhere = (sqlDataReader.GetValue(3)).ToString(),
                        });

                    }
                }
                else
                {
                    MessageBox.Show("Заказов нет!!!");
                }
                sqlCommand.Cancel();
                sqlDataReader.Close();
            }
            catch
            {
                MessageBox.Show("Error Orders");
            }
            return orders;
        }
    }
}
