using Microsoft.AspNetCore.Mvc;
using Helix.LBSService.WebAPI.Models.BaseModel;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Services;

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
        public async Task<DataResult<WholeSalesDispatchTransactionDto>> Insert([FromBody] WholeSalesDispatchTransactionDto dto)
        {
            var result = await _wholeSalesDispatchTransactionService.Insert(dto);
            return result;
        }
    }
}
