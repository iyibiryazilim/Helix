using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Helix.ProductionService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StopTransactionController : ControllerBase
	{
		IStopTransactionService _stopTransactionService;
		public StopTransactionController(IStopTransactionService stopTransactionService)
		{
			_stopTransactionService = stopTransactionService;
		}

		[HttpGet]
		public async Task<DataResult<IEnumerable<StopTransaction>>> GetAll()
		{
			var result = await _stopTransactionService.GetStopTransactionList();
			return result;
		}
	}
}
