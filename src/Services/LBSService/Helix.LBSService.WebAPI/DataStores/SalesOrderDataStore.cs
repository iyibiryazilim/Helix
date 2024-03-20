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
		ILogger<SalesOrderDataStore> _logger;
		ILG_SalesOrderService _tigerService;
		public SalesOrderDataStore(ILogger<SalesOrderDataStore> logger, ILG_SalesOrderService tigerService)
		{
			_logger = logger;
			_tigerService = tigerService;
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
