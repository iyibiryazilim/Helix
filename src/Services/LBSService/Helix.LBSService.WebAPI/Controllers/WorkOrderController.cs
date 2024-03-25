using Helix.EventBus.Base.Abstractions;
using Helix.LBSService.Base.Events;
using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Helix.LBSService.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WorkOrderController : ControllerBase
	{
		private IWorkOrderService _workOrderService;
		private IEventBus _eventBus;

		public WorkOrderController(IWorkOrderService workOrderService, IEventBus eventBus)
		{
			_workOrderService = workOrderService;
			_eventBus = eventBus;
		}

		[HttpPost("Insert")]
		public async Task<DataResult<WorkOrderDto>> Insert([FromBody] WorkOrdersDto dto)
		{
			try
			{
				var result = await _workOrderService.Insert(dto);
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