using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SalesOrderController : ControllerBase
	{
		private readonly ISalesOrderService _service;
		private ILogger<SalesOrderController> _logger;
		public SalesOrderController(ISalesOrderService service, ILogger<SalesOrderController> logger)
		{
			_service = service;
			_logger = logger;
		}


		[HttpPost("Insert")]
		public async Task<DataResult<SalesOrderDto>> Insert([FromBody] SalesOrderDto dto)
		{
			try
			{
				var result = await _service.Insert(dto);
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "SalesOrderController.Insert");
				return new DataResult<SalesOrderDto>
				{
					Data = null,
					IsSuccess = false,
					Message = ex.Message
				};
			}
		}
	}
}
