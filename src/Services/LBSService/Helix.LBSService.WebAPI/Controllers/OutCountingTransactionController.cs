using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class OutCountingTransactionController : ControllerBase
    {
		private readonly ILogger<OutCountingTransactionController> _logger;
		private readonly IOutCountingTransactionService _service;
		public OutCountingTransactionController(ILogger<OutCountingTransactionController> logger, IOutCountingTransactionService service)
		{
			_logger = logger;
			_service = service;
		}

		[HttpPost("Insert")]
		public async Task<DataResult<OutCountingTransactionDto>> Insert([FromBody] OutCountingTransactionDto dto)
		{
			try
			{
				var result = await _service.Insert(dto);
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "OutCountingTransactionController.Insert");
				return new DataResult<OutCountingTransactionDto>
				{
					Data = null,
					IsSuccess = false,
					Message = ex.Message
				};
			}
		}



	}
}
