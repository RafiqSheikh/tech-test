using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.OrderValidator
{
   public  class OrderAmountFactory: IOrderAmountFactory
    {
        public IOrderAmount GetOrderAmount(double amount)
        {
            if (amount == 0)
                return new OrderAmountZero();
            else
                return new OrderAmountNonZero();
        }
    }
}
