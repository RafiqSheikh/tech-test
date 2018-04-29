using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Configuration
{
    public interface IConfigurationsHandler
    {
        string GetConnectionString();
    }
}
