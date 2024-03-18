using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WholeSalesDispatchTransactionController : ControllerBase
	{
		 

		private readonly ILogger<WholeSalesDispatchTransactionController> _logger;
		private readonly IWholeSalesDispatchTransactionService _service;
		public WholeSalesDispatchTransactionController(ILogger<WholeSalesDispatchTransactionController> logger, IWholeSalesDispatchTransactionService service)
		{
			_logger = logger;
			_service = service;
		}

		[HttpPost("Insert")]
		public async Task<DataResult<WholeSalesDispatchTransactionDto>> Insert([FromBody] WholeSalesDispatchTransactionDto dto)
		{
			try
			{
				var result = await _service.Insert(dto);
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "WholeSalesDispatchTransactionController.Insert");
				return new DataResult<WholeSalesDispatchTransactionDto>
				{
					Data = null,
					IsSuccess = false,
					Message = ex.Message
				};
			}
		}
	}
}
