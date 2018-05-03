using Eyrebot.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eyrebot.Models
{
    public class CurrencyController : Controller
    {
        private IBinanaceCurrencyService _currencyService;
        

        public CurrencyController(IBinanaceCurrencyService currencyService)
        {
            this._currencyService = currencyService;
        }

        public async Task<IActionResult> CurrencyDetails()
        {
            ViewData["Message"] = "Currency details page";
            ViewData["Name"] = "BTC/USDT";

            

            var symbol = "BTCUSDT";
            var result = await _currencyService.GetCurrency24hTickerPriceChangeDetailsForCurrencyAsync(symbol);

            return View(result);
        }
    }
}
