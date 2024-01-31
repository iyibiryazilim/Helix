using Helix.LBSService.Tiger.Models;
using Helix.LBSService.Tiger.Services;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Helper.Mappers;
using Helix.LBSService.WebAPI.Models.BaseModel;
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
			var obj = Mapping.Mapper.Map<LG_PurchaseDispatchTransaction>(dto);
			var result = await _purchaseDispatchTransactionService.Insert(obj);
			return new DataResult<PurchaseDispatchTransactionDto>()
			{
				Data = null,
				Message = result.Message,
				IsSuccess = result.IsSuccess,
			};
         }
    }
}
