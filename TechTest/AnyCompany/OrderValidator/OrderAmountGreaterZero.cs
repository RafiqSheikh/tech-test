namespace AnyCompany.OrderValidator
{
    public class OrderAmountNonZero : IOrderAmount
    {
        public bool ValidateAmount()
        {
            return true;
        }
    }
}
