using Helix.ProductService.Application.Repository;
using Helix.ProductService.Domain.AggregateModels;
using Helix.ProductService.Domain.Models;
using Helix.ProductService.Infrastructure.Helpers.Queries;
using Helix.ProductService.Infrastructure.Helpers;
using Helix.ProductService.Infrastructure.Repository.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductService.Infrastructure.Repository;

public class ConsumableTransactionLineDataStore : BaseDataStore,IConsumableTransactionLineService
{
	ILogger<ConsumableTransactionLineDataStore> _logger;
	public ConsumableTransactionLineDataStore(IConfiguration configuration,ILogger<ConsumableTransactionLineDataStore> logger) : base(configuration)
	{
		_logger = logger;
	}

	public async Task<DataResult<ConsumableTransactionLine>> GetConsumableTransactionLineByIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<ConsumableTransactionLine>(_configuraiton).GetObjectAsync(new ConsumableTransactionLineQuery(_configuraiton).GetTransactionById(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<ConsumableTransactionLine>>> GetConsumableTransactionLinesAsync()
	{
		try
		{
			var result = await new SqlQueryHelper<ConsumableTransactionLine>(_configuraiton).GetObjectsAsync(new ConsumableTransactionLineQuery(_configuraiton).GetTransactionList());
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<ConsumableTransactionLine>>> GetConsumableTransactionLinesByCurrentCodeAsync(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<ConsumableTransactionLine>(_configuraiton).GetObjectsAsync(new ConsumableTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<ConsumableTransactionLine>>> GetConsumableTransactionLinesByCurrentIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<ConsumableTransactionLine>(_configuraiton).GetObjectsAsync(new ConsumableTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<ConsumableTransactionLine>>> GetConsumableTransactionLinesByFicheCodeAsync(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<ConsumableTransactionLine>(_configuraiton).GetObjectsAsync(new ConsumableTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<ConsumableTransactionLine>>> GetConsumableTransactionLinesByFicheIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<ConsumableTransactionLine>(_configuraiton).GetObjectsAsync(new ConsumableTransactionLineQuery(_configuraiton).GetTransactionByFicheId(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<ConsumableTransactionLine>>> GetConsumableTransactionLinesByProductCodeAsync(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<ConsumableTransactionLine>(_configuraiton).GetObjectsAsync(new ConsumableTransactionLineQuery(_configuraiton).GetTransactionByProductCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<ConsumableTransactionLine>>> GetConsumableTransactionLinesByProductIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<ConsumableTransactionLine>(_configuraiton).GetObjectsAsync(new ConsumableTransactionLineQuery(_configuraiton).GetTransactionByProductId(id));
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
