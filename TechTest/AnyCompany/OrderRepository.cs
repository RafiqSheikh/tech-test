using AnyCompany.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace AnyCompany
{
    public  class OrderRepository:IOrderRepository
    {
        public bool Save(Order order, IConfigurationsHandler configurations)
        {
            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = configurations.GetConnectionString();
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Orders VALUES (@CustomerId, @OrderId, @Amount, @VAT)", connection);
                command.Parameters.AddWithValue("@CustomerId", order.CustomerId);
                command.Parameters.AddWithValue("@OrderId", order.OrderId);
                command.Parameters.AddWithValue("@Amount", order.Amount);
                command.Parameters.AddWithValue("@VAT", order.VAT);

                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                //log error here

                return false;
            }
            finally
            {
                if (connection.State== ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
