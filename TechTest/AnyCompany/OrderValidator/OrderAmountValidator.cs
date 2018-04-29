using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.OrderValidator
{
    public class OrderAmountValidator : IOrderAmountValidator
    {
        public bool ValidateOrderAmount(IOrderAmount orderAmount)
        {          
            return orderAmount.ValidateAmount();
        }

    }
}
