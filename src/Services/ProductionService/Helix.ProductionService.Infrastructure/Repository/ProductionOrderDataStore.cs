using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Domain.AggregateModels;
using Helix.ProductionService.Domain.Models;
using Helix.ProductionService.Infrastructure.BaseRepository;
using Helix.ProductionService.Infrastructure.Helper;
using Helix.ProductionService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;

namespace Helix.ProductionService.Infrastructure.Repository;

public class ProductionOrderDataStore : BaseDataStore, IProductionOrderService
{
	public ProductionOrderDataStore(IConfiguration configuration) : base(configuration)
	{
	}

	public Task<DataResult<IEnumerable<ProductionOrder>>> GetProductionOrderList()
	{
		var result = new SqlQueryHelper<ProductionOrder>().GetObjectsAsync(new ProductionOrderQuery(_configuraiton).GetProductionOrderList());
		return result;
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
}
