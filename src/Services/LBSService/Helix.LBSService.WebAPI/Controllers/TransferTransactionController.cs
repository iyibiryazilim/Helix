using Helix.SharedEntity.DTOs;
using Helix.SharedEntity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<DataResult<TransferTransaction>> Insert([FromBody] TransferTransactionDto dto)
        {
            var result = await _transferTransactionService.Insert(dto);
            return result;
        }
    }
}
