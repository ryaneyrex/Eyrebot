using Eyrebot.Models;
using System.Threading.Tasks;

namespace Eyrebot.Services
{
    public interface IBinanceCurrencyService
    {
        Task<BinanceCurrencyDetailsModel> GetCurrency24hTickerPriceChangeDetails(string symbol);
    }
}