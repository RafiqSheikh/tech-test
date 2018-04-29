
using AnyCompany.Configuration;
using AnyCompany.OrderValidator;
using AnyCompany.VAT;
using Moq;
using NUnit.Framework;

namespace AnyCompany.Tests.CustomerOrderTest
{
    [TestFixture]
    public class CustomerOrderTests
    {
        private  Mock<IOrderAmountValidator> orderAmountValidatorMock;
        private  Mock<IVatService> vatServiceMock;
        private  Mock<IConfigurationsHandler> configurationsMock;
        private  Mock<IOrderAmountFactory> orderAmountFactoryMock;
        private Mock<IOrderRepository> orderRepositoryMock;

        [SetUp]
        public void Setup()
        {
            orderAmountFactoryMock = new Mock<IOrderAmountFactory>();
            orderAmountValidatorMock = new Mock<IOrderAmountValidator>();
            vatServiceMock = new Mock<IVatService>();
            configurationsMock = new Mock<IConfigurationsHandler>();
            orderRepositoryMock = new Mock<IOrderRepository>();


        }

        [Test]
        public void When_Customer_Order_Amount_Is_Zero_Then_Return_PlaceOrder_Is_False()
        {

            Order order = new Order
            {
                Amount = 0,
                OrderId = 1,
            };

            var orderAmountFactory = new OrderAmountFactory();
            var orderAmountValidator = new OrderAmountValidator();
            var configurations = new ConfigurationsHandler();
            var orderRepository = new OrderRepository();
            var vatService = new VatService();

            var orderAmount = orderAmountFactory.GetOrderAmount(order.Amount);

            var orderService = new OrderService(orderAmountFactory,
                                                  orderAmountValidator,
                                                  vatService,
                                                  configurations,
                                                  orderRepository);

            int customerId = 1;

            var success = orderService.PlaceOrder(order, customerId);

            Assert.That(success, Is.False);
            
        }

        [Test]
        public void When_Customer_Order_Amount_Is_Negative_Then_Return_PlaceOrder_Is_False()
        {

            Order order = new Order
            {
                Amount = -20,
                OrderId = 1,
            };

            var orderAmountFactory = new OrderAmountFactory();
             var orderAmountValidator = new OrderAmountValidator();
            var configurations = new ConfigurationsHandler();
            var orderRepository = new OrderRepository();
            var vatService = new VatService();

            var orderAmount = orderAmountFactory.GetOrderAmount(order.Amount);

            var orderService = new OrderService(orderAmountFactory,
                                                  orderAmountValidator,
                                                  vatService,
                                                  configurations,
                                                  orderRepository);

            int customerId = 1;

            var success = orderService.PlaceOrder(order, customerId);

            Assert.That(success, Is.False);

        }
        [Test]
        public void When_Customer_Order_Amount_Is_Positive_Then_Return_PlaceOrder_Is_True()
        {
            // this test fails as it is unable to connect the database
            Order order = new Order
            {
                Amount = 150,
                OrderId = 1,
            };

            var orderAmountFactory = new OrderAmountFactory();
            var orderAmountValidator = new OrderAmountValidator();
            var configurations = new ConfigurationsHandler();
            var orderRepository = new OrderRepository();
            var vatService = new VatService();

            var orderAmount = orderAmountFactory.GetOrderAmount(order.Amount);

            var orderService = new OrderService(orderAmountFactory,
                                                  orderAmountValidator,
                                                  vatService,
                                                  configurations,
                                                  orderRepository);

            int customerId = 1;

            var success = orderService.PlaceOrder(order, customerId);

            Assert.That(success, Is.True);

        }
    }
}
