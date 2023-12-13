using Helix.SharedEntity.DTOs;
using Helix.SharedEntity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumableTransactionController : ControllerBase
    {
        private readonly ILG_ConsumableTransactionService _consumableTransactionService;
        private ILogger<ConsumableTransactionController> _logger;
        public ConsumableTransactionController(ILG_ConsumableTransactionService consumableTransactionService, ILogger<ConsumableTransactionController> logger)
        {
            _consumableTransactionService = consumableTransactionService;
            _logger = logger;
        }
        [HttpPost("Insert")]
        public async Task<DataResult<ConsumableTransaction>> Insert([FromBody] ConsumableTransactionDto dto)
        {
            var result = await _consumableTransactionService.Insert(dto);
            return result;
        }
    }
}
