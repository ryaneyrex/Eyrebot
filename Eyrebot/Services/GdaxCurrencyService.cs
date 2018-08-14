using Eyrebot.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public async Task<GdaxCurrencyDetailsModel> GetProductTicker(string productId)
        {
            var result = new GdaxCurrencyDetailsModel()
            {
                Success = false,
                Message = "Failed to get currency details"
            };

            var apiUrl = _config["ApiKeys:GdaxApiUrl"];
            var tickerUrl = $"{apiUrl}/products/{productId}/ticker";

            using (var _client = new HttpClient())
            {
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                _client.DefaultRequestHeaders.Add("User-Agent", ".NET Framework Test Client");
                
                var response = await _client.GetStringAsync(tickerUrl);

                if (response.ToString().Contains("trade_id"))
                {
                    result = JsonConvert.DeserializeObject<GdaxCurrencyDetailsModel>(response);

                    result.Success = true;
                    result.Message = "Success";

                    return result;
                }

                return result;
                
            }

        }
    }
}
