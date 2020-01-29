using AnyCompany.Entities;
using AnyCompany.Repository.Interface;
using System;
using System.Data.SqlClient;

namespace AnyCompany.Repository
{
    public static class CustomerRepository
    {
        private static readonly string connectionString = @"Data Source=(local);Database=Customers;User Id=admin;Password=password;";
        private static readonly string getCustomerQuery = "SELECT * FROM Customer WHERE CustomerId = ";

        public static Customer FetchCustomer(int customerId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand(getCustomerQuery + customerId, connection))
                {
                    var cust = new Customer();
                    using (SqlDataReader rdr = command.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            try
                            {
                                cust.Country = rdr["country"].ToString();
                                cust.DateOfBirth = (DateTime)rdr["dateOfBirth"];
                                cust.Name = rdr["name"].ToString();
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }

                        }
                    }
                    return cust;
                }
            }
        }
    }
}
