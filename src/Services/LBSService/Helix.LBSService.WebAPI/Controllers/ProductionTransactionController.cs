using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Services;
using Microsoft.AspNetCore.Mvc;
using Helix.LBSService.Tiger.Models.BaseModel;
namespace Helix.LBSService.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductionTransactionController : ControllerBase
    {
        private readonly ILG_ProductionTransactionService _productionTransactionService;
        private ILogger<ProductionTransactionController> _logger;
        public ProductionTransactionController(ILG_ProductionTransactionService productionTransactionService, ILogger<ProductionTransactionController> logger)
        {
            _productionTransactionService = productionTransactionService;
            _logger = logger;
        }
        [HttpPost("Insert")]
        public async Task<DataResult<ProductionTransactionDto>> Insert([FromBody] ProductionTransactionDto dto)
        {
            var result = await _productionTransactionService.Insert(dto);
            return result;
        }
    }
}
