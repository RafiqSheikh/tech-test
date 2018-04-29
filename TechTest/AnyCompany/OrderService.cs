using AnyCompany.Configuration;
using AnyCompany.OrderValidator;
using AnyCompany.Types;
using AnyCompany.VAT;
using System;

namespace AnyCompany
{
    public class OrderService
    {
        private readonly IOrderRepository orderRepository;


        private readonly IOrderAmountValidator orderAmountValidator;
        private readonly IVatService vatService;
        private readonly IConfigurationsHandler configurations;
        private readonly IOrderAmountFactory orderAmountFactory;

        public OrderService(IOrderAmountFactory orderAmountFactory,
                            IOrderAmountValidator orderAmountValidator,
                            IVatService vatService,
                            IConfigurationsHandler configurations,
                            IOrderRepository orderRepository )
        {
            this.orderAmountFactory = orderAmountFactory;
            this.orderAmountValidator = orderAmountValidator;
            this.vatService = vatService;
            this.configurations = configurations;
            this.orderRepository = orderRepository;
        }

        public bool PlaceOrder(Order order, int customerId)
        {
            try
            {
                var orderAmount = orderAmountFactory.GetOrderAmount(order.Amount);
                var orderValidator = orderAmountValidator.ValidateOrderAmount(orderAmount);

                if (orderValidator == false) // order amount is not valid
                    return false;

                Customer customer = CustomerRepository.Load(customerId, configurations);

                if (customer == null)
                    return false;

                var vatRate = vatService.GetVatRate(customer.Country);

                order.VAT = vatRate;
                order.CustomerId = customerId;
                var success = orderRepository.Save(order, configurations);

                return success;
            }
            catch (Exception ex)
            {
                // log error here
                return false;
            }
        }
    }
}
