using AnyCompany.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AnyCompany
{
    public static class CustomerRepository
    {
        public static Customer Load(int customerId, IConfigurationsHandler configurations)
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = configurations.GetConnectionString();

                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Customer WHERE CustomerId = " + customerId,
                    connection);
                var reader = command.ExecuteReader();

                var customer = new Customer();

                while (reader.Read())
                {
                    customer.Name = reader["Name"].ToString();
                    customer.DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString());
                    customer.Country = reader["Country"].ToString();
                }
                return customer;
            }
            catch (Exception ex)
            {
                // log error here
                return null;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
    }
}
