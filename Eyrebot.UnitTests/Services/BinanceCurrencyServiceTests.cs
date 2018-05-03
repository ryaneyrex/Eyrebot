using Eyrebot.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Eyrebot.Models.UnitTests
{
    [TestClass]
    public class BinanceCurrencyServiceTests
    {
        private IBinanaceCurrencyService _binanceCurrencyService;

        [TestInitialize]
        public void Initalize()
        {
            this._binanceCurrencyService = new BinanceCurrencyService();
        }

        [TestMethod]
        public void GetCurrency24hTickerPriceChangeDetailsForCurrency_WithValidParameters_ReturnsValidResult()
        {
            var symbol = "BTCUSDT";
            var response = _binanceCurrencyService.GetCurrency24hTickerPriceChangeDetailsForCurrencyAsync(symbol);

            Assert.IsNotNull(response);
            Assert.AreEqual(symbol, response.Result.Symbol);
        }
    }
}