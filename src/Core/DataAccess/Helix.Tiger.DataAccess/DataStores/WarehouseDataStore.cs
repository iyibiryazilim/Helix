using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores
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
