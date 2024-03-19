using Helix.EventBus.Base.Abstractions;
using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Domain.Dtos;
using Helix.ProductionService.Domain.Events;
using Helix.ProductionService.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Helix.ProductionService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	//[Authorize]
	public class WorkOrderController : ControllerBase
	{
		IWorkOrderService _workOrderService;
		IEventBus _eventBus;

		public WorkOrderController(IWorkOrderService workOrderService, IEventBus eventBus)
		{
			_workOrderService = workOrderService;
			_eventBus = eventBus;
		}

		[HttpGet]
		public async Task<DataResult<IEnumerable<WorkOrder>>> GetAll()
		{
			var result = await _workOrderService.GetWorkOrderList();
			return result;
		}

		[HttpGet("Id/{id:int}")]
		public async Task<DataResult<WorkOrder>> GetById(int id)
		{
			var result = await _workOrderService.GetWorkOrderById(id);
			return result;
		}

		[HttpGet("Status")]
		public async Task<DataResult<IEnumerable<WorkOrder>>> GetByStatus([FromQuery(Name = "status")]int[] status)
		{
			var result = await _workOrderService.GetWorkOrderByStatus(status);
			return result;
		}

		[HttpGet("Workstation/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<WorkOrder>>> GetByWorkstationId(int id)
		{
			var result = await _workOrderService.GetWorkOrderByWorkstationId(id);
			return result;
		}

		[HttpGet("Workstation/Code/{code}")]
		public async Task<DataResult<IEnumerable<WorkOrder>>> GetByWorkstationCode(string code)
		{
			var result = await _workOrderService.GetWorkOrderByWorkstationCode(code);
			return result;
		}

		[HttpGet("ProductionOrder/Id/{id:int}")]
		public async Task<DataResult<IEnumerable<WorkOrder>>> GetByProductionOrderId(int id)
		{
			var result = await _workOrderService.GetWorkOrderByProductionOrderId(id);
			return result;
		}

		[HttpGet("ProductionOrder/Code/{code}")]
		public async Task<DataResult<IEnumerable<WorkOrder>>> GetByProductionOrderCode(string code)
		{
			var result = await _workOrderService.GetWorkOrderByProductionOrderCode(code);
			return result;
		}

		[HttpGet("Product/Id/{id:int}")]
		public async Task <DataResult<IEnumerable<WorkOrder>>> GetByProductId(int id)
		{
			var result= await _workOrderService.GetWorkOrderByProductId(id);
			return result;
		}




		[HttpPost("InsertActualQuantity")]
		public async Task WorkOrderInsert([FromBody] WorkOrderDto workOrderDto)
		{
			_eventBus.Publish(new WorkOrderInsertedIntegrationEvent(workOrderDto.workOrderReferenceId, workOrderDto.productReferenceId, workOrderDto.actualQuantity, workOrderDto.subUnitsetReferenceId, workOrderDto.calculatedMethod, workOrderDto.isIncludeSideProduct));
		}

		[HttpPost("WorkOrders")]
		public async Task WorkOrdersInsert([FromBody] WorkOrdersDto workOrdersDto)
		{
			_eventBus.Publish(new WorkOrdersInsertedIntegrationEvent(workOrdersDto.workOrders));
		}

		[HttpPost("ChangeStatus")]
		public async Task WorkOrderChangeStatus([FromBody] WorkOrderChangeStatusDto workOrderChangeStatusDto)
		{
			_eventBus.Publish(new WorkOrderChangeStatusInsertedIntegrationEvent(ficheNo: workOrderChangeStatusDto.ficheNo,
				status: workOrderChangeStatusDto.status,
				deleteFiche: workOrderChangeStatusDto.deleteFiche));
		}

	}
}
