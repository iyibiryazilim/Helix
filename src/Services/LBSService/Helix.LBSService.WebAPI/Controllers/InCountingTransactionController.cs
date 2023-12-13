using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Services;
 using Microsoft.AspNetCore.Mvc;
using Helix.LBSService.Tiger.Models.BaseModel;

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
        public async Task<DataResult<InCountingTransactionDto>> Insert([FromBody] InCountingTransactionDto dto)
        {
            var result = await _inCountingTransactionService.Insert(dto);
            return result;
        }


    }
}
