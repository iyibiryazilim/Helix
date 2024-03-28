using Helix.EventBus.Base.Abstractions;
using Helix.LBSService.Base.Events;
using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VariantController : ControllerBase
	{
		private readonly IVariantService _service;
		private readonly IEventBus _eventBus;

		public VariantController(IVariantService variantService, IEventBus eventBus)
		{
			_service = variantService;
			_eventBus = eventBus;
		}

		[HttpPost("Insert")]
		public async Task<DataResult<VariantDto>> Insert([FromBody] VariantDto dto)
		{
			try
			{
				var result = await _service.Insert(dto);
				return result;
			}
			catch (Exception ex)
			{
				//_eventBus.Publish(new SYSMessageIntegrationEvent(0, false, ex.Message, null, dto));
				//_eventBus.Publish(new LOGOFailureIntegrationEvent(0, ex.Message, null, dto));
				return new DataResult<VariantDto>
				{
					Data = null,
					IsSuccess = false,
					Message = ex.Message
				};
			}
		}
	}
}