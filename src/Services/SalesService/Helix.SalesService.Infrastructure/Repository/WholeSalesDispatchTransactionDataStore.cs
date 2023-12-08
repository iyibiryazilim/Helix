using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.BaseRepository;
using Helix.SalesService.Infrastructure.Helper;
using Helix.SalesService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.Tiger.DataAccess.DataStores;

public class WholeSalesDispatchTransactionDataStore : BaseDataStore, IWholeSalesDispatchTransactionService
{
	ILogger<WholeSalesDispatchTransactionDataStore> _logger;
	public WholeSalesDispatchTransactionDataStore(IConfiguration configuration, ILogger<WholeSalesDispatchTransactionDataStore> logger) : base(configuration)
	{
		_logger = logger;
	}

	public async Task<DataResult<WholeSalesDispatchTransaction>> GetWholeSalesDispatchTransactionByCode(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesDispatchTransaction>().GetObjectAsync(new WholeSalesDispatchTransactionQuery(_configuraiton).GetTransactionByCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<WholeSalesDispatchTransaction>> GetWholeSalesDispatchTransactionByIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesDispatchTransaction>().GetObjectAsync(new WholeSalesDispatchTransactionQuery(_configuraiton).GetTransactionById(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransaction>>> GetWholeSalesDispatchTransactionsAsync()
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesDispatchTransaction>().GetObjectsAsync(new WholeSalesDispatchTransactionQuery(_configuraiton).GetTransactionList());
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransaction>>> GetWholeSalesDispatchTransactionsByCurrentCodeAsync(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesDispatchTransaction>().GetObjectsAsync(new WholeSalesDispatchTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransaction>>> GetWholeSalesDispatchTransactionsByCurrentIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesDispatchTransaction>().GetObjectsAsync(new WholeSalesDispatchTransactionQuery(_configuraiton).GetTransactionByCurrentId(id));

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
