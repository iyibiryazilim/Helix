using Helix.DemandService.Domain.Dtos;
using Helix.DemandService.Domain.Events;
using Helix.EventBus.Base.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Helix.DemandService.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DemandController : ControllerBase
	{
		private IEventBus _eventbus;

		public DemandController(IEventBus eventbus)
		{
			_eventbus = eventbus;
		}

		[HttpPost]
		public async Task Insert([FromBody] DemandDto dto)
		{
			try
			{
				_eventbus.Publish(new DemandInsertingIntegrationEvent(dto.ReferenceId, dto.Date, dto.DocumentNumber, dto.SpeCode, dto.DateCreated, dto.ProjectCode, dto.Lines));
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}