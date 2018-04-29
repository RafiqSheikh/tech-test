using AnyCompany.Configuration;
using AnyCompany.VAT;
using Moq;
using NUnit.Framework;


namespace AnyCompany.Tests.VatTest
{
    [TestFixture]
   public  class VatTests
    {
        private Mock<IConfigurationsHandler> configurationsHandlerMock;
        private Mock<IVatService> vatServiceMock;
        private Mock<IVatRate> vatRateMock;

        [SetUp]
        public void Init()
        {
            configurationsHandlerMock = new Mock<IConfigurationsHandler>();
            vatServiceMock = new Mock<IVatService>();
            vatRateMock = new Mock<IVatRate>();
        }

        [Test]
        public void When_Country_Is_UK_Then_Return_VatForUK()
        {

            var vatService = new VatService();

            var vatRate = vatService.GetVatRate("UK");

            Assert.AreEqual(vatRate, 0.2);

        }

        [Test]
        public void When_Country_Is_Not_UK_Then_Return_VatForOtherCountry()
        {
            var vatService = new VatService();
            var vatRate = vatService.GetVatRate("Other");
            Assert.AreEqual(vatRate, 0);
        }

       
    }


}
