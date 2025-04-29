using BalanceCoinAPI.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BalanceCoinAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalanceController : ControllerBase
    {
        private readonly IBalanceService _balanceService;

        public BalanceController(IBalanceService balanceService)
        {
            _balanceService = balanceService;
        }

        [HttpGet]
        public async Task<ActionResult<decimal>> GetBalance()
        {
            var balance = await _balanceService.GetBalanceAsync();
            return Ok(balance);
        }
    }
}
