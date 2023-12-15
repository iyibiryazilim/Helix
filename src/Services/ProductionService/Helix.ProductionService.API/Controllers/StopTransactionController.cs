using Helix.EventBus.Base.Abstractions;
using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Domain.Dtos;
using Helix.ProductionService.Domain.Events;
using Helix.ProductionService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Helix.ProductionService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StopTransactionController : ControllerBase
	{
		IStopTransactionService _stopTransactionService;
		IEventBus _eventBus;
		public StopTransactionController(IStopTransactionService stopTransactionService, IEventBus eventBus)
		{
			_stopTransactionService = stopTransactionService;
			_eventBus = eventBus;
		}

		[HttpGet]
		public async Task<DataResult<IEnumerable<StopTransaction>>> GetAll()
		{
			var result = await _stopTransactionService.GetStopTransactionList();
			return result;
		}

		[HttpPost]
		public async Task InsertStopTransaction([FromBody] StopTransactionForWorkOrderDto stopTransactionForWorkOrderDto)
		{
			_eventBus.Publish(new StopTransactionForWorkOrderInsertingIntegrationEvent(stopTransactionForWorkOrderDto.workOrderReferenceId, stopTransactionForWorkOrderDto.stopCauseReferenceId, stopTransactionForWorkOrderDto.stopDate, stopTransactionForWorkOrderDto.stopTime));
		}
	}
}
