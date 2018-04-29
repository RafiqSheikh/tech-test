using System;
namespace AnyCompany.OrderValidator
{
    public interface IOrderAmountValidator
    {
        bool ValidateOrderAmount(IOrderAmount orderAmount);
    }
}
