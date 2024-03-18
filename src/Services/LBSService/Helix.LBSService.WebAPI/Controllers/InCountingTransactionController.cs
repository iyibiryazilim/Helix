using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class InCountingTransactionController : ControllerBase
    { 
		private readonly ILogger<InCountingTransactionController> _logger;
		private readonly IInCountingTransactionService _service;
		public InCountingTransactionController(ILogger<InCountingTransactionController> logger, IInCountingTransactionService service)
		{
			_logger = logger;
			_service = service;
		}

		[HttpPost("Insert")]
        public async Task<DataResult<InCountingTransactionDto>> Insert([FromBody] InCountingTransactionDto dto)
        {
			try
			{
				var result = await _service.Insert(dto);
				return result;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "InCountingTransactionController.Insert");
				return new DataResult<InCountingTransactionDto>
				{
					Data = null,
					IsSuccess = false,
					Message = ex.Message
				};
			}
		}


    }
}
