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
		private readonly IWorkOrderService _workOrderService;
		private readonly IEventBus _eventBus;

		public WorkOrderController(IWorkOrderService workOrderService, IEventBus eventBus)
		{
			_workOrderService = workOrderService;
			_eventBus = eventBus;
		}

		[HttpPost("Insert")]
		public async Task<DataResult<WorkOrderDto>> Insert([FromBody] WorkOrderDto dto)
		{
			var response = new DataResult<WorkOrderDto>();
			try
			{
				var result = await _workOrderService.Insert(dto);
				response.Data = dto;
				response.IsSuccess = result.IsSuccess;
				response.Message = result.Message;
				_eventBus.Publish(new SYSMessageIntegrationEvent(dto.Owner, response));

				return new DataResult<WorkOrderDto>()
				{
					Data = null,
					Message = result.Message,
					IsSuccess = result.IsSuccess,
				};
			}
			catch (Exception ex)
			{
				response.Data = dto;
				response.IsSuccess = false;
				response.Message = ex.Message;
				_eventBus.Publish(new SYSMessageIntegrationEvent(dto.Owner, response));
				return new DataResult<WorkOrderDto>()
				{
					Data = null,
					Message = ex.Message + "----" + ex.StackTrace,
					IsSuccess = false,
				};
			}
		}

		[HttpPost("Inserts")]
		public async Task<DataResult<WorkOrdersDto>> Inserts([FromBody] WorkOrdersDto dto)
		{
			var response = new DataResult<WorkOrdersDto>();
			try
			{
				var result = await _workOrderService.Inserts(dto);
				response.Data = dto;
				response.IsSuccess = result.IsSuccess;
				response.Message = result.Message;
				_eventBus.Publish(new SYSMessageIntegrationEvent(dto.Owner, response));

				return new DataResult<WorkOrdersDto>()
				{
					Data = null,
					Message = result.Message,
					IsSuccess = result.IsSuccess,
				};
			}
			catch (Exception ex)
			{
				response.Data = dto;
				response.IsSuccess = false;
				response.Message = ex.Message;
				_eventBus.Publish(new SYSMessageIntegrationEvent(dto.Owner, response));
				return new DataResult<WorkOrdersDto>()
				{
					Data = null,
					Message = ex.Message + "----" + ex.StackTrace,
					IsSuccess = false,
				};
			}
		}

		[HttpPost("StopTransaction")]
		public async Task<DataResult<StopTransactionForWorkOrderDto>> InsertStopTransaction([FromBody] StopTransactionForWorkOrderDto dto)
		{
			var response = new DataResult<StopTransactionForWorkOrderDto>();
			try
			{
				var result = await _workOrderService.InsertStopTransaction(dto);

				response.IsSuccess = result.IsSuccess;
				response.Data = dto;
				response.Message = result.Message;
				_eventBus.Publish(new SYSMessageIntegrationEvent(dto.Owner, response));

				return new DataResult<StopTransactionForWorkOrderDto>()
				{
					Data = null,
					Message = result.Message,
					IsSuccess = result.IsSuccess,
				};
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.Data = dto;
				response.Message = ex.Message;
				_eventBus.Publish(new SYSMessageIntegrationEvent(dto.Owner, response));
				return new DataResult<StopTransactionForWorkOrderDto>()
				{
					Data = null,
					Message = ex.Message + "----" + ex.StackTrace,
					IsSuccess = false,
				};
			}
		}

		[HttpPost("Status")]
		public async Task<DataResult<WorkOrderChangeStatusDto>> InsertChangeStatus([FromBody] WorkOrderChangeStatusDto dto)
		{
			var response = new DataResult<WorkOrderChangeStatusDto>();
			try
			{
				var result = await _workOrderService.InsertWorkOrderStatus(dto);
				response.IsSuccess = result.IsSuccess;
				response.Data = dto;
				response.Message = result.Message;
				_eventBus.Publish(new SYSMessageIntegrationEvent(dto.Owner, response));

				return new DataResult<WorkOrderChangeStatusDto>()
				{
					Data = null,
					Message = result.Message,
					IsSuccess = result.IsSuccess,
				};
			}
			catch (Exception ex)
			{
				response.IsSuccess = false;
				response.Data = dto;
				response.Message = ex.Message;
				_eventBus.Publish(new SYSMessageIntegrationEvent(dto.Owner, dto));
				return new DataResult<WorkOrderChangeStatusDto>()
				{
					Data = null,
					Message = ex.Message + "----" + ex.StackTrace,
					IsSuccess = false,
				};
			}
		}
	}
}