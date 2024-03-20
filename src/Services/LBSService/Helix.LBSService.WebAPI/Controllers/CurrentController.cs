using Helix.EventBus.Base.Abstractions;
using Helix.LBSService.Base.Events;
using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.Models;
using Helix.LBSService.Tiger.Services;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Helper.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CurrentController : ControllerBase
	{
		private readonly ILG_CurrentService _currentService;
		private readonly IEventBus _eventBus;

		public CurrentController(ILG_CurrentService currentService, IEventBus eventBus)
		{
			_currentService = currentService;
			_eventBus = eventBus;
		}

		[HttpPost("Insert")]
		public async Task<DataResult<CurrentDto>> Insert([FromBody] CurrentDto dto)
		{
			if (LBSParameter.IsTiger)
			{
				var obj = Mapping.Mapper.Map<LG_Current>(dto);

				var result = await _currentService.Insert(obj);
				if (result.IsSuccess)
				{
					_eventBus.Publish(new SYSMessageIntegrationEvent(0, result.IsSuccess, result.Message, null, dto));
					_eventBus.Publish(new LOGOSuccessIntegrationEvent(0, result.Message, null, dto));
				}
				else
				{
					_eventBus.Publish(new SYSMessageIntegrationEvent(0, result.IsSuccess, result.Message, null, dto));
					_eventBus.Publish(new LOGOFailureIntegrationEvent(0, result.Message, null, dto));
				}
				return new DataResult<CurrentDto>()
				{
					Data = null,
					Message = result.Message,
					IsSuccess = result.IsSuccess,
				};
			}
			else
			{
				throw new HttpRequestException("Not implemented for GO");
			}
		}
	}
}