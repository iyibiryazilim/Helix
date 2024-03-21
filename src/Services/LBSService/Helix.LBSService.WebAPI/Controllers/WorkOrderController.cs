using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Services;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WorkOrderController : ControllerBase
	{
		private ILG_WorkOrderService _workOrderService;

		public WorkOrderController(ILG_WorkOrderService workOrderService)
		{
			_workOrderService = workOrderService;
		}

		[HttpPost("Insert")]
		public async Task<DataResult<WorkOrderDto>> Insert([FromBody] WorkOrdersDto dto)
		{
			try
			{
				var result = await _workOrderService.Insert(dto);
				return new DataResult<WorkOrderDto>()
				{
					Data = null,
					Message = result.Message,
					IsSuccess = result.IsSuccess,
				};
			}
			catch (Exception ex)
			{
				return new DataResult<WorkOrderDto>()
				{
					Data = null,
					Message = ex.Message + "----" + ex.StackTrace,
					IsSuccess = false,
				};
			}
		}

		[HttpPost("StopTransaction")]
		public async Task<DataResult<WorkOrderDto>> InsertStopTransaction([FromBody] StopTransactionForWorkOrderDto dto)
		{
			try
			{
				var result = await _workOrderService.InsertStopTransaction(dto);
				return new DataResult<WorkOrderDto>()
				{
					Data = null,
					Message = result.Message,
					IsSuccess = result.IsSuccess,
				};
			}
			catch (Exception ex)
			{
				return new DataResult<WorkOrderDto>()
				{
					Data = null,
					Message = ex.Message + "----" + ex.StackTrace,
					IsSuccess = false,
				};
			}
		}

		[HttpPost("Status")]
		public async Task<DataResult<WorkOrderDto>> InsertChangeStatus([FromBody] WorkOrderChangeStatusDto dto)
		{
			try
			{
				var result = await _workOrderService.InsertWorkOrderStatus(dto);
				return new DataResult<WorkOrderDto>()
				{
					Data = null,
					Message = result.Message,
					IsSuccess = result.IsSuccess,
				};
			}
			catch (Exception ex)
			{
				return new DataResult<WorkOrderDto>()
				{
					Data = null,
					Message = ex.Message + "----" + ex.StackTrace,
					IsSuccess = false,
				};
			}
		}
	}
}