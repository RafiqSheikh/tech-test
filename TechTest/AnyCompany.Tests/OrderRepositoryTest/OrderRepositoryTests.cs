using AnyCompany.Configuration;
using Moq;
using NUnit.Framework;

namespace AnyCompany.Tests.OrderRepositoryTest
{
    [TestFixture]
    public class OrderRepositoryTests
    {
        Mock<IOrderRepository> orderRepositoryMock;
        Mock<IConfigurationsHandler> configurationsHandler;

        [SetUp]
        public void Setup()
        {
            orderRepositoryMock = new Mock<IOrderRepository>();
            configurationsHandler = new Mock<IConfigurationsHandler>();
        }

        [Test]
        public void When_Connection_String_Is_Set_Then_Return_The_Same_Connection_String()
        {
            configurationsHandler.Setup(x => x.GetConnectionString()).Returns("SqlConnectionString");

            var connectionString = configurationsHandler.Object.GetConnectionString();

            Assert.AreSame(connectionString, "SqlConnectionString");
            configurationsHandler.Verify(x => x.GetConnectionString(), Times.Once);
        }

        [Test]
        public void When_Order_Save_Successfully_Then_Return_Save_Flag_Is_True()
        {
            configurationsHandler.Setup(x => x.GetConnectionString()).Returns("SqlConnectionString");

           
            Order order = new Order
            {
                Amount = 120.0,
                OrderId = 1,
                VAT = 0.2,
                CustomerId = 1
            };

           

            orderRepositoryMock.Setup(x => x.Save(order, configurationsHandler.Object)).Returns(true);

            var success = orderRepositoryMock.Object.Save(order, configurationsHandler.Object);

            Assert.That(success, Is.True);
            orderRepositoryMock.Verify(x => x.Save(order, configurationsHandler.Object), Times.Once);
        }
        [Test]
        public void When_Order_Save_Unsuccessfully_Then_Return_Save_Flag_Is_False()
        {
            configurationsHandler.Setup(x => x.GetConnectionString()).Returns("SqlConnectionString");

            Order order = new Order
            {
                Amount = 120.0,
                OrderId = 1,
                VAT = 0.2,
                CustomerId=1
            };


            orderRepositoryMock.Setup(x => x.Save(order,  configurationsHandler.Object)).Returns(false);

            var success = orderRepositoryMock.Object.Save(order, configurationsHandler.Object);

            Assert.That(success, Is.False);
            orderRepositoryMock.Verify(x => x.Save(order,  configurationsHandler.Object), Times.Once);
        }
    }
}
