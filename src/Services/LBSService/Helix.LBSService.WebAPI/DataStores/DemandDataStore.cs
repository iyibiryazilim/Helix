using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.Models;
using Helix.LBSService.Tiger.Services;
using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Helper.Mappers;
using Helix.LBSService.WebAPI.Services;

namespace Helix.LBSService.WebAPI.DataStores
{
	public class DemandDataStore : IDemandService
	{
		private readonly ILogger<DemandDataStore> logger;
		private readonly ILG_DemandService _tigerService;

		public DemandDataStore(ILogger<DemandDataStore> logger, ILG_DemandService tigerService)
		{
			this.logger = logger;
			_tigerService = tigerService;
		}

		public async Task<DataResult<DemandDto>> Insert(DemandDto dto)
		{
			try
			{
				if (LBSParameter.IsTiger)
				{
					var obj = Mapping.Mapper.Map<LG_Demand>(dto);
					foreach (var item in dto.Lines)
					{
						var transaction = Mapping.Mapper.Map<LG_DemandLine>(item);
						obj.TRANSACTION.Add(transaction);
					}
					var result = await _tigerService.Insert(obj);

					return new DataResult<DemandDto>()
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