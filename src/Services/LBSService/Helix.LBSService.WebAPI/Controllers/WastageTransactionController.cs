using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WastageTransactionController : ControllerBase
	{
		 
		private readonly IWastageTransactionService _service;
		private readonly ILogger<WastageTransactionController> _logger;
		public WastageTransactionController(ILogger<WastageTransactionController> logger, IWastageTransactionService service)
		{
			_logger = logger;
			_service = service;
		}
		[HttpPost("Insert")]
		public async Task<DataResult<WastageTransactionDto>> Insert([FromBody] WastageTransactionDto dto)
		{
			try
			{
				var result = await _service.Insert(dto);
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "WastageTransactionController.Insert");
				return new DataResult<WastageTransactionDto>
				{
					Data = null,
					IsSuccess = false,
					Message = ex.Message
				};
			}

		}
	}
}
