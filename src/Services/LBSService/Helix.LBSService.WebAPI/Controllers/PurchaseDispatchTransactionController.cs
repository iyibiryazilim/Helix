using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Models.BaseModel;
using Helix.LBSService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class PurchaseDispatchTransactionController : ControllerBase
    {

        private readonly ILG_PurchaseDispatchTransactionService _purchaseDispatchTransactionService;
        private ILogger<PurchaseDispatchTransactionController> _logger;
        public PurchaseDispatchTransactionController(ILG_PurchaseDispatchTransactionService purchaseDispatchTransactionService, ILogger<PurchaseDispatchTransactionController> logger)
        {
            _purchaseDispatchTransactionService = purchaseDispatchTransactionService;
            _logger = logger;
        }


        [HttpPost("Insert")]
        public async Task<DataResult<PurchaseDispatchTransactionDto>> Insert([FromBody] PurchaseDispatchTransactionDto dto)
        {
            var result = await _purchaseDispatchTransactionService.Insert(dto);
            return result;
        }
    }
}
