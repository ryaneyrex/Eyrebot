using Eyrebot.Models;
using Eyrebot.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
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

        public async Task<IActionResult> CurrencyDetails(GdaxCurrencyDetailsModel vm)
        {
            ViewData["Message"] = "GDAX Currency Details";
            ViewData["Name"] = "BTC-USD";
            if (vm.Symbol == null)
            {
                vm.Symbol = "BTC-USD";
            }

            var currencyList = new List<CurrencySymbolModel>
            {
                new CurrencySymbolModel()
                {
                    Display = "BTC/USD",
                    Value = "BTC-USD"
                },
                new CurrencySymbolModel()
                {
                    Display = "BTC/EUR",
                    Value = "BTC-EUR"
                }
            };
            ViewBag.CurrencySymbols = new SelectList(currencyList, "Value", "Display");

            var result = await _currencyService.GetProductTicker(vm.Symbol);

            return View(result);
        }

        

    }
}
