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
	public class VariantDataStore : IVariantService
	{
		private readonly ILogger<VariantDataStore> _logger;
		private readonly ILG_VariantService _tigerService;
		private readonly IEventBus _eventBus;

		public VariantDataStore(ILogger<VariantDataStore> logger, ILG_VariantService tigerService, IEventBus eventBus)
		{
			_logger = logger;
			_tigerService = tigerService;
			_eventBus = eventBus;
		}

		public async Task<DataResult<VariantDto>> Insert(VariantDto dto)
		{
			try
			{
				if (LBSParameter.IsTiger)
				{
					var obj = Mapping.Mapper.Map<LG_Variant>(dto);

					foreach (var item in dto.Lines)
					{
						var variantAssign = Mapping.Mapper.Map<LG_VRNTASSIGN>(item);
						obj.VRNT_ASSIGNS.Add(variantAssign);
					}

					var result = await _tigerService.Insert(obj);

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

					return new DataResult<VariantDto>()
					{
						Data = null,
						Message = result.Message,
						IsSuccess = result.IsSuccess,
					};
				}
				else
				{
					throw new HttpRequestException("Not implemented for GO");
				}
			}
			catch (Exception ex)
			{
				_eventBus.Publish(new SYSMessageIntegrationEvent(0, false, ex.Message, null, dto));
				_eventBus.Publish(new LOGOFailureIntegrationEvent(0, ex.Message, null, dto));
				throw;
			}
		}
	}
}