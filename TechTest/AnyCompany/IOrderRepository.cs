using AnyCompany.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany
{
  public   interface IOrderRepository
    {
        bool Save(Order order, IConfigurationsHandler configurations);
    }
}
