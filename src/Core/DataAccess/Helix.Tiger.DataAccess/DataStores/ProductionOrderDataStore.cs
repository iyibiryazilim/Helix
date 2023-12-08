using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores;

public class ProductionOrderDataStore : BaseDataStore, IProductionOrderService
{
	public ProductionOrderDataStore(IConfiguration configuration) : base(configuration)
	{
	}

	public Task<DataResult<ProductionOrder>> GetProductionOrderByCode(string code)
	{
		var result = new SqlQueryHelper<ProductionOrder>().GetObjectAsync(new ProductionOrderQuery(_configuraiton).GetProductionOrderByCode(code));
		return result;
	}

	public Task<DataResult<ProductionOrder>> GetProductionOrderById(int id)
	{
		var result = new SqlQueryHelper<ProductionOrder>().GetObjectAsync(new ProductionOrderQuery(_configuraiton).GetProductionOrderById(id));
		return result;
	}

	public Task<DataResult<IEnumerable<ProductionOrder>>> GetProductionOrderList()
	{
		var result = new SqlQueryHelper<ProductionOrder>().GetObjectsAsync(new ProductionOrderQuery(_configuraiton).GetProductionOrderList());
		return result;
	}
}
