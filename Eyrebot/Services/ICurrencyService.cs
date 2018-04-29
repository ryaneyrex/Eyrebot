using System.Threading.Tasks;

namespace Eyrebot.Services
{
    public interface ICurrencyService
    {
        Task<Currency24hTickerPriceChangeDetailsResult> GetCurrency24hTickerPriceChangeDetailsForCurrencyAsync(string symbol);
    }
}