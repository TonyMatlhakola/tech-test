using AnyCompany.Entities;
using AnyCompany.Repository.Interface;
using System;
using System.Data.SqlClient;

namespace AnyCompany.Repository
{
    public static class CustomerRepository
    {
        private static readonly string connectionString = @"Data Source=(local);Database=Customers;User Id=admin;Password=password;";
        private static readonly string query = "SELECT * FROM Customer WHERE CustomerId = ";

        public static Customer Load(int customerId)
        {
            var customer = new Customer();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(query + customerId, connection))
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    customer.Name = reader["Name"].ToString();
                    customer.DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString());
                    customer.Country = reader["Country"].ToString();
                }
            }           

            return customer;
        }
    }
}
