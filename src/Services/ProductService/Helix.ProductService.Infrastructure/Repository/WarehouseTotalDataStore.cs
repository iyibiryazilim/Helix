using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductService.Infrastructure.Repository
{
	public class WarehouseTotalDataStore : BaseDataStore, IWarehouseTotalService
	{
		ILogger<WarehouseTotalDataStore> _logger;
		public WarehouseTotalDataStore(IConfiguration configuration,ILogger<WarehouseTotalDataStore> logger) : base(configuration)
		{
			_logger = logger;
		}

		public async Task<DataResult<IEnumerable<WarehouseTotal>>> GetProductsByWarehouseNumber(int number, string CardType, string search, string orderBy, int page, int pageSize)
		{
			try
			{
				var result = await new SqlQueryHelper<WarehouseTotal>().GetObjectsAsync(new WarehouseTotalQuery(_configuraiton).GetProductsByWarehouseNumber(number,CardType,search,orderBy,page,pageSize));
				_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

				return result;
			}
			catch (Exception ex)
			{
				_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

				throw;
			}
		}
	}
}
