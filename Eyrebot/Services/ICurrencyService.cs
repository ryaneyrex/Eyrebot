using Eyrebot.Models;
using System.Threading.Tasks;

namespace Eyrebot.Services
{
    public interface IBinanaceCurrencyService
    {
        Task<BinanceCurrencyDetailsModel> GetProductTicker(string symbol);
    }
}