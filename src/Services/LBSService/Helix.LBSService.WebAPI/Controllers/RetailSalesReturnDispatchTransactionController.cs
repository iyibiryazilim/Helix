using Microsoft.AspNetCore.Mvc;
using Helix.LBSService.WebAPI.Models.BaseModel;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Services;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class RetailSalesReturnDispatchTransactionController : ControllerBase
    {
        private readonly ILG_RetailSalesReturnDispatchTransactionService _retailSalesReturnDispatchTransactionService;
        private ILogger<RetailSalesReturnDispatchTransactionController> _logger;
        public RetailSalesReturnDispatchTransactionController(ILG_RetailSalesReturnDispatchTransactionService retailSalesReturnDispatchTransactionService, ILogger<RetailSalesReturnDispatchTransactionController> logger)
        {
            _retailSalesReturnDispatchTransactionService = retailSalesReturnDispatchTransactionService;
            _logger = logger;
        }

        [HttpPost("Insert")]
        public async Task<DataResult<RetailSalesReturnDispatchTransactionDto>> Insert([FromBody] RetailSalesReturnDispatchTransactionDto dto)
        {
            var result = await _retailSalesReturnDispatchTransactionService.Insert(dto);
            return result;
        }

    }
}
