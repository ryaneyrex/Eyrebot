using Eyrebot.Controllers;
using Eyrebot.Models;
using Eyrebot.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace Eyrebot.UnitTests.Controllers
{
    [TestClass]
    public class BinanceCurrencyControllerTests
    {
        private IBinanceCurrencyService _currencyService;
        private BinanceCurrencyController _currencyController;
        private IConfigurationRoot _config;

        [TestInitialize]
        public void Initalize()
        {
            var mockConfigurationRoot = new Mock<IConfigurationRoot>();
            mockConfigurationRoot.SetupGet(x => x[It.IsAny<string>()]).Returns("https://api.binance.com/api/v1");
            var config = mockConfigurationRoot.Object;
            _config = config;

            _currencyService = new BinanceCurrencyService(_config);
            _currencyController = new BinanceCurrencyController(_currencyService);
        }

        [TestMethod]
        public void Binance_CurrencyDetails_ReturnsResult()
        {
            var controller = _currencyController.CurrencyDetails();

            var result = controller.Result;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
