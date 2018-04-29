using AnyCompany.OrderValidator;
using Moq;
using NUnit.Framework;


namespace AnyCompany.Tests.OrderValidatorTest
{
    [TestFixture]
   public  class OrderValidatorTests
    {
        private Mock<IOrderAmount> validatorAmountMock;
        private Mock<IOrderAmountValidator> orderAmountValidatorMock;
        private Mock<IOrderAmountFactory> orderAmountFactoryMock;

        [SetUp]
        public void Setup()
        {
            validatorAmountMock = new Mock<IOrderAmount>();
            orderAmountValidatorMock = new Mock<IOrderAmountValidator>();
            orderAmountFactoryMock = new Mock<IOrderAmountFactory>();
        }

        [Test]
        public void When_Order_Amount_Is_Zero_Return_OrderAmountZero_Object()
        {
            var orderAmountZero = new OrderAmountZero();
            orderAmountFactoryMock.Setup(x => x.GetOrderAmount(0)).Returns(orderAmountZero);
            
            var orderAmountObj = orderAmountFactoryMock.Object.GetOrderAmount(0);

            Assert.That(orderAmountObj.GetType().Equals(typeof(OrderAmountZero)));
            orderAmountFactoryMock.Verify(x => x.GetOrderAmount(0), Times.Once);
        }

        [Test]
        public void When_Order_Amount_Is_Negative_Return_OrderAmountZero_Object()
        {
            var orderAmountZero = new OrderAmountZero();
            orderAmountFactoryMock.Setup(x => x.GetOrderAmount(-2)).Returns(orderAmountZero);

            var orderAmountObj = orderAmountFactoryMock.Object.GetOrderAmount(-2);

            Assert.That(orderAmountObj.GetType().Equals(typeof(OrderAmountZero)));
            orderAmountFactoryMock.Verify(x => x.GetOrderAmount(-2), Times.Once);
        }


        [Test]
        public void When_Order_Amount_Is_Positive_Then_Return_OrderAmountNonZero_Object()
        {
            var orderAmountNonZero = new OrderAmountNonZero();
            orderAmountFactoryMock.Setup(x => x.GetOrderAmount(230)).Returns(orderAmountNonZero);

            var orderAmountObj = orderAmountFactoryMock.Object.GetOrderAmount(230);

            Assert.That(orderAmountObj.GetType().Equals(typeof(OrderAmountNonZero)));
            orderAmountFactoryMock.Verify(x => x.GetOrderAmount(230), Times.Once);
        }

        [Test]

        public void When_Order_Amount_Is_Zero_Then_Return_Amount_Validation_Flag_Is_False()
        {
            var orderAmountZero = new OrderAmountZero();
            orderAmountFactoryMock.Setup(x => x.GetOrderAmount(0)).Returns(orderAmountZero);
            orderAmountValidatorMock.Setup(x => x.ValidateOrderAmount(orderAmountZero)).Returns(false);

            var orderAmountObj = orderAmountFactoryMock.Object.GetOrderAmount(0);
            var validationFlag = orderAmountValidatorMock.Object.ValidateOrderAmount(orderAmountObj);

            Assert.That(orderAmountObj.GetType().Equals(typeof(OrderAmountZero)));
            Assert.That(validationFlag, Is.False);
            orderAmountFactoryMock.Verify(x => x.GetOrderAmount(0), Times.Once);
            orderAmountValidatorMock.Verify(x => x.ValidateOrderAmount(orderAmountZero), Times.Once);
        }
        [Test]
        public void When_Order_Amount_Is_Negative_Then_Return_Amount_Validation_Flag_Is_False()
        {
            var orderAmountZero = new OrderAmountZero();
            orderAmountFactoryMock.Setup(x => x.GetOrderAmount(-2)).Returns(orderAmountZero);
            orderAmountValidatorMock.Setup(x => x.ValidateOrderAmount(orderAmountZero)).Returns(false);

            var orderAmountObj = orderAmountFactoryMock.Object.GetOrderAmount(-2);
            var validationFlag = orderAmountValidatorMock.Object.ValidateOrderAmount(orderAmountObj);

            Assert.That(orderAmountObj.GetType().Equals(typeof(OrderAmountZero)));
            Assert.That(validationFlag, Is.False);
            orderAmountFactoryMock.Verify(x => x.GetOrderAmount(-2), Times.Once);
            orderAmountValidatorMock.Verify(x => x.ValidateOrderAmount(orderAmountZero), Times.Once);
        }

        [Test]
        public void When_Order_Amount_Is_Positive_Then_Return_Amount_Validation_Flag_Is_True()
        {
            var orderAmountNonZero = new OrderAmountNonZero();
            orderAmountFactoryMock.Setup(x => x.GetOrderAmount(120)).Returns(orderAmountNonZero);
            orderAmountValidatorMock.Setup(x => x.ValidateOrderAmount(orderAmountNonZero)).Returns(false);

            var orderAmountObj = orderAmountFactoryMock.Object.GetOrderAmount(120);
            var validationFlag = orderAmountValidatorMock.Object.ValidateOrderAmount(orderAmountObj);

            Assert.That(orderAmountObj.GetType().Equals(typeof(OrderAmountNonZero)));
            Assert.That(validationFlag, Is.False);
            orderAmountFactoryMock.Verify(x => x.GetOrderAmount(120), Times.Once);
            orderAmountValidatorMock.Verify(x => x.ValidateOrderAmount(orderAmountNonZero), Times.Once);
        }

    }
}
