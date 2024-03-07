using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Domain.AggregateModels;
using Helix.ProductionService.Domain.Models;
using Helix.ProductionService.Infrastructure.BaseRepository;
using Helix.ProductionService.Infrastructure.Helper;
using Helix.ProductionService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductionService.Infrastructure.Repository;

public class ProductionTransactionLineDataStore : BaseDataStore, IProductionTransactionLineService
{
	ILogger<ProductionTransactionLineDataStore> _logger;
	public ProductionTransactionLineDataStore(IConfiguration configuration, ILogger<ProductionTransactionLineDataStore> logger) : base(configuration)
	{
		_logger = logger;
	}

	public async Task<DataResult<ProductionTransactionLine>> GetProductionTransactionLineByIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<ProductionTransactionLine>(_configuraiton).GetObjectAsync(new ProductionTransactionLineQuery(_configuraiton).GetTransactionById(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
			return result;
		} catch(Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}
		
	}

	public async Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetProductionTransactionLinesAsync()
	{
		try
		{
			var result = await new SqlQueryHelper<ProductionTransactionLine>(_configuraiton).GetObjectsAsync(new ProductionTransactionLineQuery(_configuraiton).GetTransactionList());
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}

	}

	public async Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetProductionTransactionLinesByCurrentCodeAsync(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<ProductionTransactionLine>(_configuraiton).GetObjectsAsync(new ProductionTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}

	}

	public async Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetProductionTransactionLinesByCurrentIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<ProductionTransactionLine>(_configuraiton).GetObjectsAsync(new ProductionTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}
		
	}

	public async Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetProductionTransactionLinesByFicheCodeAsync(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<ProductionTransactionLine>(_configuraiton).GetObjectsAsync(new ProductionTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}


	}

	public async Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetProductionTransactionLinesByFicheIdAsync(int id)
	{
		
		try
		{
			var result = await new SqlQueryHelper<ProductionTransactionLine>(_configuraiton).GetObjectsAsync(new ProductionTransactionLineQuery(_configuraiton).GetTransactionByFicheId(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}
	}

	public async Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetProductionTransactionLinesByProductCodeAsync(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<ProductionTransactionLine>(_configuraiton).GetObjectsAsync(new ProductionTransactionLineQuery(_configuraiton).GetTransactionByProductCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}

	}

	public async Task<DataResult<IEnumerable<ProductionTransactionLine>>> GetProductionTransactionLinesByProductIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<ProductionTransactionLine>(_configuraiton).GetObjectsAsync(new ProductionTransactionLineQuery(_configuraiton).GetTransactionByProductId(id));
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
