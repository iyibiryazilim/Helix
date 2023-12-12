using Helix.SharedEntity.DTOs;
using Helix.SharedEntity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<DataResult<RetailSalesReturnDispatchTransaction>> Insert([FromBody] RetailSalesReturnDispatchTransactionDto dto)
        {
            var result = await _retailSalesReturnDispatchTransactionService.Insert(dto);
            return result;
        }

    }
}
