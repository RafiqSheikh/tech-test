namespace AnyCompany.OrderValidator
{
    public class OrderAmountZero : IOrderAmount
    {
        public bool ValidateAmount()
        {
            return false;
        }
    }
}
