using Helix.SharedEntity.DTOs;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<DataResult<RetailSalesDispatchTransaction>> Insert([FromBody] RetailSalesDispatchTransactionDto dto)
        {
            var result = await _retailSalesDispatchTransactionService.Insert(dto);
            return result;
        }
    }
}
