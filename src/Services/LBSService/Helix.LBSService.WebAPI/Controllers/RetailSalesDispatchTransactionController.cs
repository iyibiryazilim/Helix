using Microsoft.AspNetCore.Mvc;
using Helix.LBSService.WebAPI.Models.BaseModel;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Services;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class RetailSalesDispatchTransactionController : ControllerBase
    {
        private readonly ILG_RetailSalesDispatchTransactionService _retailSalesDispatchTransactionService;
        private ILogger<RetailSalesDispatchTransactionController> _logger;
        public RetailSalesDispatchTransactionController(ILG_RetailSalesDispatchTransactionService retailSalesDispatchTransactionService, ILogger<RetailSalesDispatchTransactionController> logger)
        {
            _retailSalesDispatchTransactionService = retailSalesDispatchTransactionService;
            _logger = logger;
        }

        [HttpPost("Insert")]
        public async Task<DataResult<RetailSalesDispatchTransactionDto>> Insert([FromBody] RetailSalesDispatchTransactionDto dto)
        {
            var result = await _retailSalesDispatchTransactionService.Insert(dto);
            return result;
        }
    }
}
