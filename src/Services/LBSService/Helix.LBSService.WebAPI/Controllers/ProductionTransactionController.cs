using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductionTransactionController : ControllerBase
	{
		private readonly IProductionTransactionService _service;
		private ILogger<ProductionTransactionController> _logger;

		public ProductionTransactionController(ILogger<ProductionTransactionController> logger, IProductionTransactionService service)
		{
			_logger = logger;
			_service = service;
		}
		[HttpPost("Insert")]
		public async Task<DataResult<ProductionTransactionDto>> Insert([FromBody] ProductionTransactionDto dto)
		{ 
			try
			{
				var result = await _service.Insert(dto);
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "ProductionTransactionController.Insert");
				return new DataResult<ProductionTransactionDto>
				{
					Data = null,
					IsSuccess = false,
					Message = ex.Message
				};
			}
 		}
	}
}
