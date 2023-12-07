
using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;

namespace Helix.ProductService.Infrastructure.Repository
{
	public class WarehouseDataStore : BaseDataStore, IWarehouseService
	{
		public WarehouseDataStore(IConfiguration configuration) : base(configuration)
		{
		}

		public Task<DataResult<IEnumerable<Warehouse>>> GetWarehouseList()
		{
			var result = new SqlQueryHelper<Warehouse>().GetObjectsAsync(new WarehouseQuery(_configuraiton).GetWarehouseList());
			return result;
		}
	}
}
