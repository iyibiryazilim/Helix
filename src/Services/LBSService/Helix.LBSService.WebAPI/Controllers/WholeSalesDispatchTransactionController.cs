using Helix.SharedEntity.DTOs;
using Helix.SharedEntity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WholeSalesDispatchTransactionController : ControllerBase
    {
        private readonly ILG_WholeSalesDispatchTransactionService _wholeSalesDispatchTransactionService;
        private ILogger<WholeSalesDispatchTransactionController> _logger;
        public WholeSalesDispatchTransactionController(ILG_WholeSalesDispatchTransactionService wholeSalesDispatchTransactionService, ILogger<WholeSalesDispatchTransactionController> logger)
        {
            _wholeSalesDispatchTransactionService = wholeSalesDispatchTransactionService;
            _logger = logger;
        }
        [HttpPost("Insert")]
        public async Task<DataResult<WholeSalesDispatchTransaction>> Insert([FromBody] WholeSalesDispatchTransactionDto dto)
        {
            var result = await _wholeSalesDispatchTransactionService.Insert(dto);
            return result;
        }
    }
}
