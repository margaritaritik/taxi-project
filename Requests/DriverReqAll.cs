using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using Такси.Models;

namespace Такси.Requests
{
    public class DriverReqAll
    {
        public static List<Driver> GetAllDrivers()
        {
            List<Driver> orders = new List<Driver>();
            try
            {
                string connString = @"Data Source =.\SQLEXPRESS; Initial Catalog = Такси; integrated Security = True; ";
                //string connString = @"Data Source =localhost\SQLEXPRESS ; Initial Catalog = Такси; integrated Security = True; ";
                SqlConnection sqlConnection = new SqlConnection(connString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand($"select * from Водитель;", sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        orders.Add(new Driver()
                        {
                            Id = Convert.ToInt32(sqlDataReader.GetValue(0)),
                            FullName = (sqlDataReader.GetValue(1)).ToString(),
                            Phone = (sqlDataReader.GetValue(2)).ToString(),
                            Login = (sqlDataReader.GetValue(3)).ToString(),
                            Password= (sqlDataReader.GetValue(4)).ToString(),
                            LevelId = Convert.ToInt32(sqlDataReader.GetValue(5)),
                            CarId = Convert.ToInt32(sqlDataReader.GetValue(6))

                         });
                        //string a = (sqlDataReader.GetValue(0)).ToString();
                        //MessageBox.Show($"Вы вошли с Id={a}");
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
    }
}
