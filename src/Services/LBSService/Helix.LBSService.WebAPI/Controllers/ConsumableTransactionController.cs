using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Services;
using Helix.SharedEntity.Models;
using Microsoft.AspNetCore.Mvc;
using Helix.LBSService.Tiger.Models.BaseModel;


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
        public async Task<DataResult<ConsumableTransactionDto>> Insert([FromBody] ConsumableTransactionDto dto)
        {
            var result = await _consumableTransactionService.Insert(dto);
            return result;
        }
    }
}
