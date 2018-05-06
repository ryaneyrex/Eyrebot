using System.Threading.Tasks;
using Eyrebot.Models;

namespace Eyrebot.Services
{
    public interface IGdaxCurrencyService
    {
        Task<GdaxCurrencyDetailsModel> GetProductTicker(string symbol);
    }
}