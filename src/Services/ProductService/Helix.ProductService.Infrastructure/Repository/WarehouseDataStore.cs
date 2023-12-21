
using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductService.Infrastructure.Repository
{
	public class WarehouseDataStore : BaseDataStore, IWarehouseService
	{
        private readonly ILogger<WarehouseDataStore> _logger;
        public WarehouseDataStore(IConfiguration configuration, ILogger<WarehouseDataStore> logger) : base(configuration)
		{
            _logger = logger;
        }

		public async Task<DataResult<IEnumerable<Warehouse>>> GetWarehouseList(string search, string orderBy, int page, int pageSize)
		{
			try
			{
                var result = await new SqlQueryHelper<Warehouse>().GetObjectsAsync(new WarehouseQuery(_configuraiton).GetWarehouseList(search,orderBy,page,pageSize));
                return result;
            }
			catch (Exception ex)
			{
                _logger.LogWarning(ex.Message, DateTime.UtcNow.ToLongTimeString());
                throw;
            }
		}
	}
}
