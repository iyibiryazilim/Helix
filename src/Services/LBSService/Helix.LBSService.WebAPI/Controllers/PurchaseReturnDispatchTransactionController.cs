using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.Models;
using Helix.LBSService.Tiger.Services;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Helper.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class PurchaseReturnDispatchTransactionController : ControllerBase
    {
        private readonly ILG_PurchaseReturnDispatchTransactionService _purchaseReturnDispatchTransactionService;
        private ILogger<PurchaseReturnDispatchTransactionController> _logger;
        public PurchaseReturnDispatchTransactionController(ILG_PurchaseReturnDispatchTransactionService purchaseReturnDispatchTransactionService, ILogger<PurchaseReturnDispatchTransactionController> logger)
        {
            _purchaseReturnDispatchTransactionService = purchaseReturnDispatchTransactionService;
            _logger = logger;
        }
        [HttpPost("Insert")]
        public async Task<DataResult<PurchaseReturnDispatchTransactionDto>> Insert([FromBody] PurchaseReturnDispatchTransactionDto dto)
        {
			var obj = Mapping.Mapper.Map<LG_PurchaseReturnDispatchTransaction>(dto);
			foreach (var item in dto.Lines)
			{
				var transaction = Mapping.Mapper.Map<LG_PurchaseReturnDispatchTransactionLine>(item);
				obj.TRANSACTIONS.Add(transaction);
			}
			var result = await _purchaseReturnDispatchTransactionService.Insert(obj);
			return new DataResult<PurchaseReturnDispatchTransactionDto>()
			{
				Data = null,
				Message = result.Message,
				IsSuccess = result.IsSuccess,
			};
         }

    }
}
