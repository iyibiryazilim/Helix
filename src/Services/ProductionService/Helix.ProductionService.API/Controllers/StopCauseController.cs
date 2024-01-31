using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Helix.ProductionService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class StopCauseController : ControllerBase
	{
		IStopCauseService _stopCauseService;
		public StopCauseController(IStopCauseService stopCauseService)
		{
			_stopCauseService = stopCauseService;
		}

		[HttpGet]
		public async Task<DataResult<IEnumerable<StopCause>>> GetAll()
		{
			var result = await _stopCauseService.GetStopCauseList();
			return result;
		}
	}
}
