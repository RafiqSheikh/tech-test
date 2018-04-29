using AnyCompany.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AnyCompany
{
    public class OrderRepository : IOrderRepository
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
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        public IEnumerable<Order> GetOrders(int customerId, IConfigurationsHandler configurations)
        {

            SqlConnection connection = new SqlConnection();
            try
            {
                connection.ConnectionString = configurations.GetConnectionString();
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Orders WHERE CustomerId = " + customerId, connection);

                var reader = command.ExecuteReader();

                var orders = new List<Order>();

                while (reader.Read())
                {
                    orders.Add(
                            new Order
                            {
                                OrderId = Convert.ToInt32(reader["OrderId"]),
                                CustomerId = Convert.ToInt32(reader["CustomerId"]),
                                Amount = Convert.ToDouble(reader["Amount"]),
                                VAT = Convert.ToInt32(reader["VAT"]),
                            });
                }
                return orders;

            }
            catch (Exception ex)
            {
                //log error here
                return null;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
