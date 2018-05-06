﻿using Eyrebot.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Eyrebot.Models.UnitTests
{
    [TestClass]
    public class BinanceCurrencyServiceTests
    {
        private IBinanaceCurrencyService _binanceCurrencyService;
        private IConfigurationRoot _config;

        [TestInitialize]
        public void Initalize()
        {
            var mockConfigurationRoot = new Mock<IConfigurationRoot>();
            mockConfigurationRoot.SetupGet(x => x[It.IsAny<string>()]).Returns("https://api.binance.com/api/v1");
            var config = mockConfigurationRoot.Object;
            _config = config;

            this._binanceCurrencyService = new BinanceCurrencyService(_config);
        }

        [TestMethod]
        public void GetCurrency24hTickerPriceChangeDetailsForCurrency_WithValidParameters_ReturnsValidResult()
        {
            var symbol = "BTCUSDT";
            var response = _binanceCurrencyService.GetProductTicker(symbol);

            Assert.IsNotNull(response.Result);
            Assert.AreEqual(symbol, response.Result.Symbol);
        }


    }
}