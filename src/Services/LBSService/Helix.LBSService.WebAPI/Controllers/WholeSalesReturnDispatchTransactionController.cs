using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;


namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WholeSalesReturnDispatchTransactionController : ControllerBase
	{
		private ILogger<WholeSalesReturnDispatchTransactionController> _logger;
		private IWholeSalesReturnDispatchTransactionService _service;

		public WholeSalesReturnDispatchTransactionController(IWholeSalesReturnDispatchTransactionService service, ILogger<WholeSalesReturnDispatchTransactionController> logger)
		{
			_service = service;
			_logger = logger;
		}

		[HttpPost("Insert")]
		public async Task<DataResult<WholeSalesReturnTransactionDto>> Insert([FromBody] WholeSalesReturnTransactionDto dto)
		{
			try
			{
				var result = await _service.Insert(dto);
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "WholeSalesReturnTransactionController.Insert");
				return new DataResult<WholeSalesReturnTransactionDto>
				{
					Data = null,
					IsSuccess = false,
					Message = ex.Message
				};
			}
		}
	}
}
