using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Helix.ProductionService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WorkOrderController : ControllerBase
	{
		IWorkOrderService _workOrderService;

		public WorkOrderController(IWorkOrderService workOrderService)
		{
			_workOrderService = workOrderService;
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

	}
}
