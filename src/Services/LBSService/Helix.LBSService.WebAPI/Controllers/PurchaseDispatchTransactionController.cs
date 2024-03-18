using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class PurchaseDispatchTransactionController : ControllerBase
    { 
		private readonly ILogger<PurchaseDispatchTransactionController> _logger;
		private readonly IPurchaseDispatchTransactionService _service;
		public PurchaseDispatchTransactionController(ILogger<PurchaseDispatchTransactionController> logger, IPurchaseDispatchTransactionService service)
		{
			_logger = logger;
			_service = service;
		}

		[HttpPost("Insert")]
        public async Task<DataResult<PurchaseDispatchTransactionDto>> Insert([FromBody] PurchaseDispatchTransactionDto dto)
        {
			try
			{
				var result = await _service.Insert(dto);
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "PurchaseDispatchTransactionController.Insert");
				return new DataResult<PurchaseDispatchTransactionDto>
				{
					Data = null,
					IsSuccess = false,
					Message = ex.Message
				};
			}
		}
    }
}
