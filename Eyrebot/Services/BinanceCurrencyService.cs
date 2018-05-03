using Eyrebot.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Eyrebot.Services
{
    public class BinanceCurrencyService : IBinanaceCurrencyService
    {
        /// <summary>
        /// Returns 24h ticker price change details for a currency
        /// </summary>
        /// <param name="symbol">Name of the currency e.g BTCUSDT</param>
        /// <returns></returns>
        public async Task<BinanceCurrencyDetailsModel> GetCurrency24hTickerPriceChangeDetailsForCurrencyAsync(string symbol)
        {
            var result = new BinanceCurrencyDetailsModel()
            {
                Success = false,
                Message = "Failed to get currency details"
            };

            var url = $"https://api.binance.com/api/v1/ticker/24hr?symbol={symbol}";

            var client = new HttpClient();

            var json = await client.GetStringAsync(url);
            
            var results = JObject.Parse(json);
            if (results.ToString().Contains("symbol"))
            {
                result.Success = true;
                result.Message = "Success";

                result.Symbol = results["symbol"].ToString();
                result.PriceChange = decimal.Parse(results["priceChange"].ToString());
                result.PriceChangePercent = decimal.Parse(results["priceChangePercent"].ToString());
                result.WeightedAvgPrice = decimal.Parse(results["weightedAvgPrice"].ToString());
                result.PrevClosePrice = decimal.Parse(results["prevClosePrice"].ToString());
                result.LastPrice = decimal.Parse(results["lastPrice"].ToString());
                result.LastQty = decimal.Parse(results["lastQty"].ToString());
                result.BidPrice = decimal.Parse(results["bidPrice"].ToString());
                result.BidQty = decimal.Parse(results["bidQty"].ToString());
                result.AskPrice = decimal.Parse(results["askPrice"].ToString());
                result.AskQty = decimal.Parse(results["askQty"].ToString());
                result.OpenPrice = decimal.Parse(results["openPrice"].ToString());
                result.HighPrice = decimal.Parse(results["highPrice"].ToString());
                result.LowPrice = decimal.Parse(results["lowPrice"].ToString());
                result.Volume = decimal.Parse(results["volume"].ToString());
                result.QuoteVolume = decimal.Parse(results["quoteVolume"].ToString());
                result.OpenTime = Int64.Parse(results["openTime"].ToString());
                result.CloseTime = Int64.Parse(results["closeTime"].ToString());
                result.FirstId = Int64.Parse(results["firstId"].ToString());
                result.LastId = Int64.Parse(results["lastId"].ToString());
                result.Count = Int64.Parse(results["count"].ToString());
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
