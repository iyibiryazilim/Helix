using Helix.EventBus.Base.Abstractions;
using Helix.LBSService.Base.Events;
using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.Models;
using Helix.LBSService.Tiger.Services;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Helper.Mappers;
using Helix.LBSService.WebAPI.Services;

namespace Helix.LBSService.WebAPI.DataStores
{
	public class SalesOrderDataStore : ISalesOrderService
	{
		private ILogger<SalesOrderDataStore> _logger;
		private ILG_SalesOrderService _tigerService;
		private IEventBus _eventBus;

		public SalesOrderDataStore(ILogger<SalesOrderDataStore> logger, ILG_SalesOrderService tigerService, IEventBus eventBus)
		{
			_logger = logger;
			_tigerService = tigerService;
			_eventBus = eventBus;
		}

		public async Task<DataResult<SalesOrderDto>> Insert(SalesOrderDto dto)
		{
			if (LBSParameter.IsTiger)
			{
				try
				{
					var obj = Mapping.Mapper.Map<LG_SalesOrder>(dto);
					foreach (var item in dto.Lines)
					{
						var transaction = Mapping.Mapper.Map<LG_SalesOrderLine>(item);
						obj.TRANSACTIONS.Add(transaction);
					}
					var result = await _tigerService.Insert(obj);
					if (result.IsSuccess)
					{
						_eventBus.Publish(new SYSMessageIntegrationEvent(dto.ReferenceId, result.IsSuccess, result.Message, string.IsNullOrEmpty(dto.EmployeeOid) ? null : new Guid(dto.EmployeeOid), dto));
						_eventBus.Publish(new LOGOSuccessIntegrationEvent(dto.ReferenceId, result.Message, string.IsNullOrEmpty(dto.EmployeeOid) ? null : new Guid(dto.EmployeeOid), dto));
					}
					else
					{
						_eventBus.Publish(new SYSMessageIntegrationEvent(dto.ReferenceId, result.IsSuccess, result.Message, string.IsNullOrEmpty(dto.EmployeeOid) ? null : new Guid(dto.EmployeeOid), dto));
						_eventBus.Publish(new LOGOFailureIntegrationEvent(dto.ReferenceId, result.Message, string.IsNullOrEmpty(dto.EmployeeOid) ? null : new Guid(dto.EmployeeOid), dto));
					}
					return new DataResult<SalesOrderDto>()
					{
						Data = null,
						Message = result.Message,
						IsSuccess = result.IsSuccess,
					};
				}
				catch (Exception)
				{
					throw;
				}
			}
			else
			{
				return new DataResult<SalesOrderDto>()
				{
					Data = null,
					Message = "Not Implemented",
					IsSuccess = false,
				};
			}
		}
	}
}