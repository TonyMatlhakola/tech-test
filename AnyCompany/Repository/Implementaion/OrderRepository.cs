using AnyCompany.Entities;
using AnyCompany.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AnyCompany.Repository
{
    internal class OrderRepository : IOrderRepository
    {
        private  readonly string connectionString = @"Data Source=(local);Database=Orders;User Id=admin;Password=password;";
        private  readonly string SaveOrderQuery = "INSERT INTO Orders VALUES (@OrderId, @Amount, @VAT)";
        private readonly string GetAllCustomersWithOrdersQuery = "SELECT Customer.Name, Customer.DateOfBirth, Customer.Country, Order.OrderNo FROM Customer INNER JOIN Order ON Customer.CustomerId=Order.CustomerId";

        
        public DataSet LoadAllCustomerAndOrders(DataSet dataset)
        {
            using (var connection = new SqlConnection(connectionString)) {
                connection.Open();
                try
                {
                    SqlDataAdapter adapter = new SqlDataAdapter
                    {
                        SelectCommand = new SqlCommand(GetAllCustomersWithOrdersQuery, connection)
                    };
                    adapter.Fill(dataset);
                    return dataset;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public void SaveOrder(Order order)
        {

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(SaveOrderQuery + order, connection))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@OrderId", order.OrderId);
                        command.Parameters.AddWithValue("@Amount", order.Amount);
                        command.Parameters.AddWithValue("@VAT", order.VAT);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

            }
            }

        }



    }
}
