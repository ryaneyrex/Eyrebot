using Eyrebot.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Eyrebot.Services
{
    public class BinanceCurrencyService : IBinanceCurrencyService
    {
        private IConfigurationRoot _config;

        public BinanceCurrencyService(IConfigurationRoot config)
        {
            _config = config;
        }


        public async Task<BinanceCurrencyDetailsModel> GetCurrency24hTickerPriceChangeDetails(string symbol)
        {
            var result = new BinanceCurrencyDetailsModel()
            {
                Success = false,
                Message = "Failed to get currency details"
            };

            var apiUrl = _config["ApiKeys:BinanceApiUrl"];
            var url = $"{apiUrl}/ticker/24hr?symbol={symbol}";

            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                
                var response = JObject.Parse(json);
                if (response.ToString().Contains("symbol"))
                {
                    result = JsonConvert.DeserializeObject<BinanceCurrencyDetailsModel>(response.ToString());

                    result.Success = true;
                    result.Message = "Success";

                    return result;
                }
            }
            result.Message = $"Unable to retrieve {symbol} currency details";
            // Todo : Log error
            return result;
        }
    }
}
