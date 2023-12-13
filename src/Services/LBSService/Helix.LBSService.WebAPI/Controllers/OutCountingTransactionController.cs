using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Services;
using Microsoft.AspNetCore.Mvc;
using Helix.LBSService.Tiger.Models.BaseModel;

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
        public async Task<DataResult<OutCountingTransactionDto>> Insert([FromBody] OutCountingTransactionDto dto)
        {
            var result = await _outCountingTransactionService.Insert(dto);
            return result;
        }

    }
}
