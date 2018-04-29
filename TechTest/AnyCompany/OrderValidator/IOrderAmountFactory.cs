using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.OrderValidator
{
   public  interface IOrderAmountFactory
    {
        IOrderAmount GetOrderAmount(double amount);
    }
}
