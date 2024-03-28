using Helix.EventBus.Base.Abstractions;
using Helix.LBSService.Base.Events;
using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Services;
using Helix.LBSService.WebAPI.Services;

namespace Helix.LBSService.WebAPI.DataStores
{
	public class WorkOrderDataStore : IWorkOrderService
	{
		private ILG_WorkOrderService _tigerService;
		private ILogger<WorkOrderDataStore> _logger;
		private IEventBus _eventBus;

		public WorkOrderDataStore(ILG_WorkOrderService tigerService, ILogger<WorkOrderDataStore> logger, IEventBus eventBus)
		{
			_tigerService = tigerService;
			_logger = logger;
			_eventBus = eventBus;
		}

		public async Task<DataResult<WorkOrderDto>> Insert(WorkOrderDto dto)
		{
			try
			{
				if (LBSParameter.IsTiger)
				{
					var result = await _tigerService.Insert(dto);
					if (result.IsSuccess)
					{
						//_eventBus.Publish(new SYSMessageIntegrationEvent(0, result.IsSuccess, result.Message, null, dto));
						_eventBus.Publish(new LOGOSuccessIntegrationEvent(0, result.Message, null, dto));
					}
					else
					{
						//_eventBus.Publish(new SYSMessageIntegrationEvent(0, result.IsSuccess, result.Message, null, dto));
						_eventBus.Publish(new LOGOFailureIntegrationEvent(0, result.Message, null, dto));
					}
					return new DataResult<WorkOrderDto>()
					{
						Data = null,
						Message = result.Message,
						IsSuccess = result.IsSuccess,
					};
				}
				else
				{
					throw new NotImplementedException();
				}
			}
			catch (Exception)
			{
				throw;
			}
			throw new NotImplementedException();
		}

		public async Task<DataResult<WorkOrderDto>> Inserts(WorkOrdersDto dto)
		{
			try
			{
				if (LBSParameter.IsTiger)
				{
					var result = await _tigerService.Inserts(dto);
					if (result.IsSuccess)
					{
						//_eventBus.Publish(new SYSMessageIntegrationEvent(0, result.IsSuccess, result.Message, null, dto));
						_eventBus.Publish(new LOGOSuccessIntegrationEvent(0, result.Message, null, dto));
					}
					else
					{
						//_eventBus.Publish(new SYSMessageIntegrationEvent(0, result.IsSuccess, result.Message, null, dto));
						_eventBus.Publish(new LOGOFailureIntegrationEvent(0, result.Message, null, dto));
					}
					return new DataResult<WorkOrderDto>()
					{
						Data = null,
						Message = result.Message,
						IsSuccess = result.IsSuccess,
					};
				}
				else
				{
					throw new NotImplementedException();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<DataResult<WorkOrderDto>> InsertStopTransaction(StopTransactionForWorkOrderDto dto)
		{
			try
			{
				if (LBSParameter.IsTiger)
				{
					var result = await _tigerService.InsertStopTransaction(dto);
					if (result.IsSuccess)
					{
						//_eventBus.Publish(new SYSMessageIntegrationEvent(0, result.IsSuccess, result.Message, null, dto));
						_eventBus.Publish(new LOGOSuccessIntegrationEvent(0, result.Message, null, dto));
					}
					else
					{
						//_eventBus.Publish(new SYSMessageIntegrationEvent(0, result.IsSuccess, result.Message, null, dto));
						_eventBus.Publish(new LOGOFailureIntegrationEvent(0, result.Message, null, dto));
					}
					return new DataResult<WorkOrderDto>()
					{
						Data = null,
						Message = result.Message,
						IsSuccess = result.IsSuccess,
					};
				}
				else
				{
					throw new NotImplementedException();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public async Task<DataResult<WorkOrderDto>> InsertWorkOrderStatus(WorkOrderChangeStatusDto dto)
		{
			try
			{
				if (LBSParameter.IsTiger)
				{
					var result = await _tigerService.InsertWorkOrderStatus(dto);
					if (result.IsSuccess)
					{
						//_eventBus.Publish(new SYSMessageIntegrationEvent(0, result.IsSuccess, result.Message, null, dto));
						_eventBus.Publish(new LOGOSuccessIntegrationEvent(0, result.Message, null, dto));
					}
					else
					{
						//_eventBus.Publish(new SYSMessageIntegrationEvent(0, result.IsSuccess, result.Message, null, dto));
						_eventBus.Publish(new LOGOFailureIntegrationEvent(0, result.Message, null, dto));
					}
					return new DataResult<WorkOrderDto>()
					{
						Data = null,
						Message = result.Message,
						IsSuccess = result.IsSuccess,
					};
				}
				else
				{
					throw new NotImplementedException();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}