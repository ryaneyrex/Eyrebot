using Eyrebot.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Eyrebot.Controllers
{
    public class GdaxCurrencyController : Controller
    {
        private IGdaxCurrencyService _currencyService;
        

        public GdaxCurrencyController(IGdaxCurrencyService currencyService)
        {
            this._currencyService = currencyService;
        }

        public async Task<IActionResult> GetCurrencyDetails()
        {
            ViewData["Message"] = "GDAX Currency Details";
            ViewData["Name"] = "BTC-USD";

            

            var symbol = "BTC-USD";
            var result = await _currencyService.GetProductTicker(symbol);

            return View(result);
        }

    }
}
