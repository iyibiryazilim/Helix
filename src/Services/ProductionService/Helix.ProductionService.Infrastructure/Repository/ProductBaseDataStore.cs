using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Domain.Models;
using Helix.ProductionService.Domain.Models.BaseModels;
using Helix.ProductionService.Infrastructure.BaseRepository;
using Helix.ProductionService.Infrastructure.Helper;
using Helix.ProductionService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductionService.Infrastructure.Repository;

public class ProductBaseDataStore : BaseDataStore, IProductService
{
	ILogger<ProductBaseDataStore> _logger;
	public ProductBaseDataStore(IConfiguration configuration, ILogger<ProductBaseDataStore> logger) : base(configuration)
	{
		_logger = logger;
	}

	public async Task<DataResult<Product>> GetProductByCode(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<Product>(_configuraiton).GetObjectAsync(new ProductQuery(_configuraiton).GetProductByCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
			return result;
		} catch(Exception ex) {
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}
		
	}

	public async Task<DataResult<Product>> GetProductById(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<Product>(_configuraiton).GetObjectAsync(new ProductQuery(_configuraiton).GetProductById(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
			return result;
		} catch(Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}
	}

	public async Task<DataResult<IEnumerable<Product>>> GetProductList()
	{
		try
		{
			var result = await new SqlQueryHelper<Product>(_configuraiton).GetObjectsAsync(new ProductQuery(_configuraiton).GetProductList());
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
