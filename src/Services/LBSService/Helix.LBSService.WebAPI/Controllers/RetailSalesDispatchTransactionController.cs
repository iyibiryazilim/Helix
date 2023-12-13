using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Services;
using Microsoft.AspNetCore.Mvc;
using Helix.LBSService.Tiger.Models.BaseModel;

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
