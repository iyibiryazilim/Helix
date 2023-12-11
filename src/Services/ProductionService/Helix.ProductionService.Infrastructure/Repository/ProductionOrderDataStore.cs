using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Domain.AggregateModels;
using Helix.ProductionService.Domain.Models;
using Helix.ProductionService.Infrastructure.BaseRepository;
using Helix.ProductionService.Infrastructure.Helper;
using Helix.ProductionService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductionService.Infrastructure.Repository;

public class ProductionOrderDataStore : BaseDataStore, IProductionOrderService
{
	ILogger<ProductionOrderDataStore> _logger;
	public ProductionOrderDataStore(IConfiguration configuration, ILogger<ProductionOrderDataStore> logger) : base(configuration)
	{
		_logger = logger;
	}

	public async Task<DataResult<IEnumerable<ProductionOrder>>> GetProductionOrderList()
	{
		try
		{
			var result = await new SqlQueryHelper<ProductionOrder>().GetObjectsAsync(new ProductionOrderQuery(_configuraiton).GetProductionOrderList());
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
			return result;
		} catch(Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}
		
	}

	public async Task<DataResult<ProductionOrder>> GetProductionOrderByCode(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<ProductionOrder>().GetObjectAsync(new ProductionOrderQuery(_configuraiton).GetProductionOrderByCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}

	}

	public async Task<DataResult<ProductionOrder>> GetProductionOrderById(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<ProductionOrder>().GetObjectAsync(new ProductionOrderQuery(_configuraiton).GetProductionOrderById(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
			return result;
		} catch(Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}
		
	}
}
