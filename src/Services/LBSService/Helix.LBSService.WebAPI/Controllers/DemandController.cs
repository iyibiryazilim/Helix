using Helix.EventBus.Base.Abstractions;
using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DemandController : ControllerBase
	{
		private readonly IEventBus _eventBus;
		private readonly IDemandService _demandService;

		public DemandController(IEventBus eventBus, IDemandService demandService)
		{
			_eventBus = eventBus;
			_demandService = demandService;
		}

		[HttpPost("Insert")]
		public async Task<DataResult<DemandDto>> Insert([FromBody] DemandDto dto)
		{
			try
			{
				return await _demandService.Insert(dto);
			}
			catch (Exception ex)
			{
				return new DataResult<DemandDto>()
				{
					Data = null,
					Message = ex.Message,
					IsSuccess = false,
				};
			}
		}
	}
}