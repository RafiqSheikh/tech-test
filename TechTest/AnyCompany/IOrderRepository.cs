using AnyCompany.Configuration;
using System.Collections.Generic;


namespace AnyCompany
{
    public interface IOrderRepository
    {
        bool Save(Order order, IConfigurationsHandler configurations);
        IEnumerable<Order> GetOrders(int customerId, IConfigurationsHandler configurations);
    }
}
