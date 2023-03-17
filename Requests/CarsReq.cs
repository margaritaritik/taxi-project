using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using Такси.Models;

namespace Такси.Requests
{
    public class CarsReq
    {
        public static int GetCarId()
        {
            int id = 1;
            try
            {
                string connString = @"Data Source =.\SQLEXPRESS; Initial Catalog = Такси; integrated Security = True; ";
                //string connString = @"Data Source =localhost\SQLEXPRESS ; Initial Catalog = Такси; integrated Security = True; ";
                SqlConnection sqlConnection = new SqlConnection(connString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"SELECT TOP 1 * FROM Автомобиль ORDER BY Id_авто DESC;", sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {

                        id = Convert.ToInt32(sqlDataReader.GetValue(0));
                           
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
            return id;
        }
    }
}
