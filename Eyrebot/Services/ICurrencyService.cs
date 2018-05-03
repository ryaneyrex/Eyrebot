using Eyrebot.Models;
using System.Threading.Tasks;

namespace Eyrebot.Services
{
    public interface IBinanaceCurrencyService
    {
        Task<BinanceCurrencyDetailsModel> GetCurrency24hTickerPriceChangeDetailsForCurrencyAsync(string symbol);
    }
}