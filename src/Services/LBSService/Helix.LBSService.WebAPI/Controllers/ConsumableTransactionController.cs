using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc; 
namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ConsumableTransactionController : ControllerBase
	{
		private readonly IConsumableTransactionService _service;
		private ILogger<ConsumableTransactionController> _logger;
		public ConsumableTransactionController(ILogger<ConsumableTransactionController> logger, IConsumableTransactionService service)
		{
			_logger = logger;
			_service = service;
		}
		[HttpPost("Insert")]
		public async Task<DataResult<ConsumableTransactionDto>> Insert([FromBody] ConsumableTransactionDto dto)
		{
			try
			{
				var result = await _service.Insert(dto);
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "ConsumableTransactionController.Insert");
				return new DataResult<ConsumableTransactionDto>
				{
					Data = null,
					IsSuccess = false,
					Message = ex.Message
				};
			}
		}
	}
}
