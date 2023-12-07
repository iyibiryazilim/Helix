using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Domain.Models;
using Helix.ProductionService.Domain.Models.BaseModels;
using Helix.ProductionService.Infrastructure.BaseRepository;
using Helix.ProductionService.Infrastructure.Helper;
using Helix.ProductionService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;

namespace Helix.ProductionService.Infrastructure.Repository;

public class ProductBaseDataStore : BaseDataStore, IProductService
{
	public ProductBaseDataStore(IConfiguration configuration) : base(configuration)
	{
	}

	public Task<DataResult<Product>> GetProductByCode(string code)
	{
		var result = new SqlQueryHelper<Product>().GetObjectAsync(new ProductQuery(_configuraiton).GetProductByCode(code));
		return result;
	}

	public Task<DataResult<Product>> GetProductById(int id)
	{
		var result = new SqlQueryHelper<Product>().GetObjectAsync(new ProductQuery(_configuraiton).GetProductById(id));
		return result;
	}

	public Task<DataResult<IEnumerable<Product>>> GetProductList()
	{
		var result = new SqlQueryHelper<Product>().GetObjectsAsync(new ProductQuery(_configuraiton).GetProductList());
		return result;
	}
}
