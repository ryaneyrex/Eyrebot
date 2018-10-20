using Eyrebot.Controllers;
using Eyrebot.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Eyrebot.UnitTests.Controllers
{
    [TestClass]
    public class GdaxCurrencyControllerTests
    {
        private IGdaxCurrencyService _currencyService;
        private GdaxCurrencyController _currencyController;
        private IConfigurationRoot _config;

        [TestInitialize]
        public void Initalize()
        {
            var mockConfigurationRoot = new Mock<IConfigurationRoot>();
            mockConfigurationRoot.SetupGet(x => x[It.IsAny<string>()]).Returns("https://api.gdax.com");
            var config = mockConfigurationRoot.Object;
            _config = config;

            _currencyService = new GdaxCurrencyService(_config);
            _currencyController = new GdaxCurrencyController(_currencyService);
        }

        [TestMethod]
        public void Gdax_CurrencyDetails_ReturnsResult()
        {
            var controller = _currencyController.CurrencyDetails();

            var result = controller.Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
