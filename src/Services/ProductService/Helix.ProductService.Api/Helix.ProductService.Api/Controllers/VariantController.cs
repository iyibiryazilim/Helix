using Helix.EventBus.Base.Abstractions;
using Helix.ProductService.Domain.Dtos;
using Helix.ProductService.Domain.Events;
using Microsoft.AspNetCore.Mvc;

namespace Helix.ProductService.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VariantController : ControllerBase
	{
		private readonly IEventBus _eventbus;

		public VariantController(IEventBus eventbus)
		{
			_eventbus = eventbus;
		}

		[HttpPost]
		public async Task VariantInsert([FromBody] VariantDto dto)
		{
			try
			{
				_eventbus.Publish(new VariantInsertingIntegrationEvent(dto.CardType, dto.Code, dto.Name, dto.UnitsetCode, dto.ProductCode, dto.Lines));
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}