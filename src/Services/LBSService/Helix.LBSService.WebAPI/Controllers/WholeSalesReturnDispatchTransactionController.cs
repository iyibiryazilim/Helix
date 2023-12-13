using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Services;
using Microsoft.AspNetCore.Mvc;
using Helix.LBSService.Tiger.Models.BaseModel;

namespace Helix.LBSService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WholeSalesReturnDispatchTransactionController : ControllerBase
    {
        private readonly ILG_WholeSalesReturnDispatchTransactionService _wholeSalesReturnDispatchTransactionService;
        private ILogger<WholeSalesReturnDispatchTransactionController> _logger;
        public WholeSalesReturnDispatchTransactionController(ILG_WholeSalesReturnDispatchTransactionService wholeSalesReturnDispatchTransactionService, ILogger<WholeSalesReturnDispatchTransactionController> logger)
        {
            _wholeSalesReturnDispatchTransactionService = wholeSalesReturnDispatchTransactionService;
            _logger = logger;
        }

        [HttpPost("Insert")]
        public async Task<DataResult<WholeSalesReturnTransactionDto>> Insert([FromBody] WholeSalesReturnTransactionDto dto)
        {
            var result = await _wholeSalesReturnDispatchTransactionService.Insert(dto);
            return result;
        }
    }
}
