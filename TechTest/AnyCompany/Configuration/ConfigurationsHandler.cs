using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Configuration
{
    public class ConfigurationsHandler : IConfigurationsHandler
    {
        public string GetConnectionString()
        {
            return @"Data Source=(local);Database=Orders;User Id=admin;Password=password;";
        }
    }
}
