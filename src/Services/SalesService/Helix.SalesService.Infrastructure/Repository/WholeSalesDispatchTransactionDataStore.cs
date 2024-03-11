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
			var result = await new SqlQueryHelper<WholeSalesDispatchTransaction>(_configuraiton).GetObjectAsync(new WholeSalesDispatchTransactionQuery(_configuraiton).GetTransactionByCode(code));
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
			var result = await new SqlQueryHelper<WholeSalesDispatchTransaction>(_configuraiton).GetObjectAsync(new WholeSalesDispatchTransactionQuery(_configuraiton).GetTransactionById(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransaction>>> GetWholeSalesDispatchTransactionsAsync(string search = "", string orderBy = WholeSalesDispatchOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesDispatchTransaction>(_configuraiton).GetObjectsAsync(new WholeSalesDispatchTransactionQuery(_configuraiton).GetTransactionList(search,orderBy,page,pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransaction>>> GetWholeSalesDispatchTransactionsByCurrentCodeAsync(string code, string search = "", string orderBy = WholeSalesDispatchOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesDispatchTransaction>(_configuraiton).GetObjectsAsync(new WholeSalesDispatchTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code, search, orderBy, page, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransaction>>> GetWholeSalesDispatchTransactionsByCurrentIdAsync(int id, string search = "", string orderBy = WholeSalesDispatchOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesDispatchTransaction>(_configuraiton).GetObjectsAsync(new WholeSalesDispatchTransactionQuery(_configuraiton).GetTransactionByCurrentId(id, search, orderBy, page, pageSize));

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
