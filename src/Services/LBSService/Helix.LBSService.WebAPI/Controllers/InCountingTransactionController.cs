using Helix.SharedEntity.DTOs;
using Helix.SharedEntity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InCountingTransactionController : ControllerBase
    {
        private readonly ILG_InCountingTransactionService _inCountingTransactionService;
        private ILogger<InCountingTransactionController> _logger;
        public InCountingTransactionController(ILG_InCountingTransactionService inCountingTransactionService, ILogger<InCountingTransactionController> logger)
        {
            _inCountingTransactionService = inCountingTransactionService;
            _logger = logger;
        }

        [HttpPost("Insert")]
        public async Task<DataResult<InCountingTransaction>> Insert([FromBody] InCountingTransactionDto dto)
        {
            var result = await _inCountingTransactionService.Insert(dto);
            return result;
        }


    }
}
