using Helix.SharedEntity.DTOs;
using Helix.SharedEntity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutCountingTransactionController : ControllerBase
    {
        private readonly ILG_OutCountingTransactionService _outCountingTransactionService;
        private ILogger<OutCountingTransactionController> _logger;
        public OutCountingTransactionController(ILG_OutCountingTransactionService outCountingTransactionService, ILogger<OutCountingTransactionController> logger)
        {
            _outCountingTransactionService = outCountingTransactionService;
            _logger = logger;
        }

        [HttpPost("Insert")]
        public async Task<DataResult<OutCountingTransaction>> Insert([FromBody] OutCountingTransactionDto dto)
        {
            var result = await _outCountingTransactionService.Insert(dto);
            return result;
        }

    }
}
