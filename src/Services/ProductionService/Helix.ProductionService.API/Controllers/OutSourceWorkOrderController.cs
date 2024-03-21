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
	public class OutSourceWorkOrderController : ControllerBase
	{
		private IOutsourceWorkOrderService _outsourceWorkOrderService;
		private IEventBus _eventBus;

		public OutSourceWorkOrderController(IOutsourceWorkOrderService outsourceWorkOrderService, IEventBus eventBus)
		{
			_outsourceWorkOrderService = outsourceWorkOrderService;
			_eventBus = eventBus;
		}

		[HttpGet]
		public async Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetAll()
		{
			var result = await _outsourceWorkOrderService.GetOutSourceWorkOrderList();
			return result;
		}

		[HttpGet("Id/{id:int}")]
		public async Task<DataResult<OutsourceWorkOrder>> GetById(int id)
		{
			var result = await _outsourceWorkOrderService.GetOutSourceWorkOrderById(id);
			return result;
		}

		[HttpGet("Status")]
		public async Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetByStatus([FromQuery(Name = "status")] int[] status)
		{
			var result = await _outsourceWorkOrderService.GetOutSourceWorkOrderByStatus(status);
			return result;
		}

		[HttpGet("Workstation/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetByWorkstationId(int id)
		{
			var result = await _outsourceWorkOrderService.GetOutSourceWorkOrderByWorkstationId(id);
			return result;
		}

		[HttpGet("Workstation/Code/{code}")]
		public async Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetByWorkstationCode(string code)
		{
			var result = await _outsourceWorkOrderService.GetOutSourceWorkOrderByWorkstationCode(code);
			return result;
		}

		[HttpGet("ProductionOrder/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetByProductionOrderId(int id)
		{
			var result = await _outsourceWorkOrderService.GetOutSourceWorkOrderByProductionOrderId(id);
			return result;
		}

		[HttpGet("ProductionOrder/Code/{code}")]
		public async Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetByProductionOrderCode(string code)
		{
			var result = await _outsourceWorkOrderService.GetOutSourceWorkOrderByProductionOrderCode(code);
			return result;
		}

		[HttpGet("Product/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<OutsourceWorkOrder>>> GetByProductId(int id)
		{
			var result = await _outsourceWorkOrderService.GetOutSourceWorkOrderByProductId(id);
			return result;
		}

		[HttpPost("InsertActualQuantity")]
		public async Task WorkOrderInsertActualQuantityInsert([FromBody] WorkOrderDto workOrderDto)
		{
			_eventBus.Publish(new OutSourceWorkOrderInsertActualQuantityIntegrationEvent(workOrderDto.workOrderReferenceId, workOrderDto.productReferenceId, workOrderDto.actualQuantity, workOrderDto.subUnitsetReferenceId, workOrderDto.calculatedMethod, workOrderDto.isIncludeSideProduct));
		}

		[HttpPost("WorkOrders")]
		public async Task WorkOrdersInsert([FromBody] WorkOrdersDto workOrdersDto)
		{
			_eventBus.Publish(new WorkOrdersInsertedIntegrationEvent(workOrdersDto.workOrders));
		}

		[HttpPost("ChangeStatus")]
		public async Task WorkOrderChangeStatus([FromBody] WorkOrderChangeStatusDto workOrderChangeStatusDto)
		{
			_eventBus.Publish(new OutSourceWorkOrderChangeStatusInsertedIntegrationEvent(ficheNo: workOrderChangeStatusDto.ficheNo,
				status: workOrderChangeStatusDto.status,
				deleteFiche: workOrderChangeStatusDto.deleteFiche));
		}

		[HttpPost("StopTransaction")]
		public async Task WorkOrderStopTransaction([FromBody] StopTransactionForWorkOrderDto stopTransactionForWorkOrderDto)
		{
			_eventBus.Publish(new OutSourceWorkOrderStopTransactionInsertingIntegrationEvent(stopTransactionForWorkOrderDto.workOrderReferenceId, stopTransactionForWorkOrderDto.stopCauseReferenceId, stopTransactionForWorkOrderDto.stopDate, stopTransactionForWorkOrderDto.stopTime));
		}
	}
}