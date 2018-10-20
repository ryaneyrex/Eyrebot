using Eyrebot.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eyrebot.Controllers
{
    public class BinanceCurrencyController : Controller
    {
        private IBinanceCurrencyService _currencyService;
        

        public BinanceCurrencyController(IBinanceCurrencyService currencyService)
        {
            this._currencyService = currencyService;
        }

        public async Task<IActionResult> CurrencyDetails()
        {
            ViewData["Message"] = "Currency details page";
            ViewData["Name"] = "BTC/USDT";

            

            var symbol = "BTCUSDT";
            var result = await _currencyService.GetCurrency24hTickerPriceChangeDetails(symbol);

            return View(result);
        }
    }
}
