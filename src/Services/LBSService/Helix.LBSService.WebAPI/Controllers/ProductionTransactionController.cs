using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<DataResult<ProductionTransaction>> Insert([FromBody] ProductionTransactionInsertDto dto)
        {
            var result = await _productionTransactionService.Insert(dto);
            return result;
        }
    }
}
