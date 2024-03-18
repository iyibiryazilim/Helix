using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PurchaseReturnDispatchTransactionController : ControllerBase
	{ 
		private readonly ILogger<PurchaseReturnDispatchTransactionController> _logger;
		private readonly IPurchaseReturnDispatchTransactionService _service;
		public PurchaseReturnDispatchTransactionController(ILogger<PurchaseReturnDispatchTransactionController> logger, IPurchaseReturnDispatchTransactionService service)
		{
			_logger = logger;
			_service = service;
		}
		[HttpPost("Insert")]
		public async Task<DataResult<PurchaseReturnDispatchTransactionDto>> Insert([FromBody] PurchaseReturnDispatchTransactionDto dto)
		{
			try
			{
				var result = await _service.Insert(dto);
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "PurchaseReturnDispatchTransactionController.Insert");
				return new DataResult<PurchaseReturnDispatchTransactionDto>
				{
					Data = null,
					IsSuccess = false,
					Message = ex.Message
				};
			}
		}

	}
}
