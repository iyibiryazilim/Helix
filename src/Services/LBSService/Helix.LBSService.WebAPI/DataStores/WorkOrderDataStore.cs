using Helix.EventBus.Base.Abstractions;
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

		public async Task<DataResult<WorkOrderDto>> Insert(WorkOrdersDto dto)
		{
			try
			{
				if (LBSParameter.IsTiger)
				{
					var result = await _tigerService.Insert(dto);
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