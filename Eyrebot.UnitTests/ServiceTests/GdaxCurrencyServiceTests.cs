using Eyrebot.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace Eyrebot.Models.UnitTests
{
    [TestClass]
    public class GdaxCurrencyServiceTests
    {
        private IGdaxCurrencyService _gdaxCurrencyService;
        private IConfigurationRoot _config;

        [TestInitialize]
        public void Initalize()
        {
            var mockConfigurationRoot = new Mock<IConfigurationRoot>();
            mockConfigurationRoot.SetupGet(x => x[It.IsAny<string>()]).Returns("https://api.gdax.com");
            var config = mockConfigurationRoot.Object;
            _config = config;

            this._gdaxCurrencyService = new GdaxCurrencyService(_config);
        }

        [TestMethod]
        public void Gdax_GetProductTicker_WithValidParameters_ReturnsValidResult()
        {
            var symbol = "BTC-USD";
            var response = _gdaxCurrencyService.GetProductTicker(symbol);

            Assert.IsTrue(response.Result.Success);
        }
    }
}