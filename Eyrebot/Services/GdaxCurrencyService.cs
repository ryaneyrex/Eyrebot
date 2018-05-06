using Eyrebot.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Eyrebot.Services
{
    public class GdaxCurrencyService : IGdaxCurrencyService
    {
        private IConfigurationRoot _config;

        public GdaxCurrencyService(IConfigurationRoot config)
        {
            _config = config;
        }

        public async Task<GdaxCurrencyDetailsModel> GetProductTicker(string symbol)
        {
            var result = new GdaxCurrencyDetailsModel()
            {
                Success = false,
                Message = "Failed to get currency details"
            };

            var apiUrl = _config["ApiKeys:Gdax"];
            var url = $"{apiUrl}/products/{symbol}/ticker";

            var client = new HttpClient();

            var json = await client.GetStringAsync(url);
            
            var results = JObject.Parse(json);
            if (results.ToString().Contains("symbol"))
            {
                result.Success = true;
                result.Message = "Success";

                result.Symbol = results["symbol"].ToString();
                result.TradeId = Int32.Parse(results["trade_id"].ToString());
                result.Price = decimal.Parse(results["price"].ToString());
                result.Size = decimal.Parse(results["size"].ToString());
                result.Bid = decimal.Parse(results["bid"].ToString());
                result.Ask = decimal.Parse(results["ask"].ToString());
                result.Volume = decimal.Parse(results["volume"].ToString());
                result.Time = DateTime.Parse(results["time"].ToString());
            }
            else
            {
                result.Message = $"Unable to retrieve {symbol} currency details";
                // Todo : Log error
            }
            return result;

        }
    }
}
