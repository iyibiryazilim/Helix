using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Domain.AggregateModels;
using Helix.ProductionService.Domain.Models;
using Helix.ProductionService.Infrastructure.BaseRepository;
using Helix.ProductionService.Infrastructure.Helper;
using Helix.ProductionService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductionService.Infrastructure.Repository;

public class ProductionTransactionDataStore : BaseDataStore, IProductionTransactionService
{
	ILogger<ProductionTransactionDataStore> _logger;
	public ProductionTransactionDataStore(IConfiguration configuration, ILogger<ProductionTransactionDataStore> logger) : base(configuration)
	{
		_logger = logger;
	}

	public async Task<DataResult<ProductionTransaction>> GetProductionTransactionByCode(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<ProductionTransaction>().GetObjectAsync(new ProductionTransactionQuery(_configuraiton).GetTransactionByCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
			return result;
		} catch(Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}
		
	}

	public async Task<DataResult<ProductionTransaction>> GetProductionTransactionByIdAsync(int id)
	{
		try
		{
			var result =await new SqlQueryHelper<ProductionTransaction>().GetObjectAsync(new ProductionTransactionQuery(_configuraiton).GetTransactionById(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
			return result;
		} catch(Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}
		
	}

	public async Task<DataResult<IEnumerable<ProductionTransaction>>> GetProductionTransactionsAsync()
	{
		try
		{
			var result = await new SqlQueryHelper<ProductionTransaction>().GetObjectsAsync(new ProductionTransactionQuery(_configuraiton).GetTransactionList());
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
			return result;
		} catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}

	}

	public async Task<DataResult<IEnumerable<ProductionTransaction>>> GetProductionTransactionsByCurrentCodeAsync(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<ProductionTransaction>().GetObjectsAsync(new ProductionTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}

	}

	public async Task<DataResult<IEnumerable<ProductionTransaction>>> GetProductionTransactionsByCurrentIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<ProductionTransaction>().GetObjectsAsync(new ProductionTransactionQuery(_configuraiton).GetTransactionByCurrentId(id));
			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}

	}
}
