using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Models.BaseModel;
using Helix.LBSService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WorkOrderController : ControllerBase
	{
		ILG_WorkOrderService _workOrderService;
        public WorkOrderController(ILG_WorkOrderService workOrderService)
        {
			_workOrderService = workOrderService;
		}
        [HttpPost("Insert")]
		public async Task<DataResult<WorkOrderDto>> Insert([FromBody] WorkOrdersDto dto)
		{

			return await _workOrderService.Insert(dto);
		}
		[HttpPost("StopTransaction")]
		public async Task<DataResult<WorkOrderDto>> InsertStopTransaction([FromBody] StopTransactionForWorkOrderDto dto)
		{
			return await _workOrderService.InsertStopTransaction(dto);
		}
		[HttpPost("Status")]
		public async Task<DataResult<WorkOrderDto>> InsertChangeStatus([FromBody] WorkOrderChangeStatusDto dto)
		{

			return await _workOrderService.InsertWorkOrderStatus(dto);
		}

	}
}
