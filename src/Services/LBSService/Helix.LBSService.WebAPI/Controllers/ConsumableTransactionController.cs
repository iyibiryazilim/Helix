using Helix.LBSService.Go.Services;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Models.BaseModel;
using Helix.LBSService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;


namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ConsumableTransactionController : ControllerBase
	{
		private readonly ILG_STFICHE_Context _stficheService;
		private readonly ILG_ConsumableTransactionService _consumableTransactionService;
		private ILogger<ConsumableTransactionController> _logger;
		public ConsumableTransactionController(ILG_ConsumableTransactionService consumableTransactionService, ILG_STFICHE_Context stficheService, ILogger<ConsumableTransactionController> logger)
		{
			_stficheService = stficheService;
			_consumableTransactionService = consumableTransactionService;
			_logger = logger;
		}
		[HttpPost("Insert")]
		public async Task<DataResult<ConsumableTransactionDto>> Insert([FromBody] ConsumableTransactionDto dto)
		{

			var result = await _consumableTransactionService.Insert(dto);
			return result;

		}
	}
}
