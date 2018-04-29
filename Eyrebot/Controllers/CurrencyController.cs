using Eyrebot.Services;
using Eyrebot.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eyrebot.Controllers
{
    public class CurrencyController : Controller
    {
        private ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public async Task<IActionResult> CurrencyDetails(CurrencyDetailsViewModel currencyDetails)
        {
            ViewData["Message"] = "Currency details page";
            ViewData["Name"] = "BTC/USDT";

            currencyDetails.Name = "BTCUSDT";
            var result = await _currencyService.GetCurrency24hTickerPriceChangeDetailsForCurrencyAsync(currencyDetails.Name);

            ViewData["LastPrice"] = result.LastPrice;
            ViewData["PriceChangePercent"] = result.PriceChangePercent;
            ViewData["WeightedAvgPrice"] = result.WeightedAvgPrice;
            ViewData["PrevClosePrice"] = result.PrevClosePrice;
            ViewData["HighPrice"] = result.HighPrice;
            ViewData["LowPrice"] = result.LowPrice;
            ViewData["Volume"] = result.Volume;

            return View();
        }
    }
}
