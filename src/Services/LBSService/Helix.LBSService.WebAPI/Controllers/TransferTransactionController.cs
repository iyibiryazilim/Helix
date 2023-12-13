using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Services;
using Microsoft.AspNetCore.Mvc;
using Helix.LBSService.Tiger.Models.BaseModel;

namespace Helix.LBSService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferTransactionController : ControllerBase
    {
        private readonly ILG_TransferTransactionService _transferTransactionService;
        private ILogger<TransferTransactionController> _logger;
        public TransferTransactionController(ILG_TransferTransactionService transferTransactionService, ILogger<TransferTransactionController> logger)
        {
            _transferTransactionService = transferTransactionService;
            _logger = logger;
        }

        [HttpPost("Insert")]
        public async Task<DataResult<TransferTransactionDto>> Insert([FromBody] TransferTransactionDto dto)
        {
            var result = await _transferTransactionService.Insert(dto);
            return result;
        }
    }
}
