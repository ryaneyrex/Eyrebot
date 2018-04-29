using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Eyrebot.Services.UnitTests
{
    [TestClass]
    public class CurrencyServiceTests
    {
        private const string _symbol = "BTCUSDT";

        private ICurrencyService _currencyService;

        [TestInitialize]
        public void Initalize()
        {
            _currencyService = new CurrencyService();
        }

        [TestMethod]
        public void GetCurrency24hTickerPriceChangeDetailsForCurrency_WithValidParameters()
        { 
            var response = _currencyService.GetCurrency24hTickerPriceChangeDetailsForCurrencyAsync("BTCUSDT");

            Assert.IsNotNull(response);
            Assert.AreEqual(_symbol, response.Result.Symbol);
        }
    }
}