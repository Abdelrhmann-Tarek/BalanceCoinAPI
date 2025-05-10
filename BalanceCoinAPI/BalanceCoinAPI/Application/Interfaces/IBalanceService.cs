using System.Threading.Tasks;

namespace BalanceCoinAPI.Application.Interfaces
{
    public interface IBalanceService
    {
        Task<decimal> GetBalanceAsync();
    }
}
