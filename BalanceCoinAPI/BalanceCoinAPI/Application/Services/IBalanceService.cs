using System.Threading.Tasks;

namespace BalanceCoinAPI.Application.Services
{
    public interface IBalanceService
    {
        Task<decimal> GetBalanceAsync();
    }
}
