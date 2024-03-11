using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.BaseRepository;
using Helix.SalesService.Infrastructure.Helper;
using Helix.SalesService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.Tiger.DataAccess.DataStores;

public class WholeSalesReturnDispatchTransactionDataStore : BaseDataStore,IWholeSalesReturnDispatchTransactionService
{
	ILogger<WholeSalesReturnDispatchTransactionDataStore> _logger;
	public WholeSalesReturnDispatchTransactionDataStore(IConfiguration configuration,ILogger<WholeSalesReturnDispatchTransactionDataStore> logger) : base(configuration)
	{
		_logger = logger;
	}

	public async Task<DataResult<WholeSalesReturnDispatchTransaction>> GetWholeSalesReturnDispatchTransactionByCode(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesReturnDispatchTransaction>(_configuraiton).GetObjectAsync(new WholeSalesReturnDispatchTransactionQuery(_configuraiton).GetTransactionByCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<WholeSalesReturnDispatchTransaction>> GetWholeSalesReturnDispatchTransactionByIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesReturnDispatchTransaction>(_configuraiton).GetObjectAsync(new WholeSalesReturnDispatchTransactionQuery(_configuraiton).GetTransactionById(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>>> GetWholeSalesReturnDispatchTransactionsAsync(string search = "", string orderBy = WholeSalesReturnDispatchOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesReturnDispatchTransaction>(_configuraiton).GetObjectsAsync(new WholeSalesReturnDispatchTransactionQuery(_configuraiton).GetTransactionList(search, orderBy, page, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>>> GetWholeSalesReturnDispatchTransactionsByCurrentCodeAsync(string code, string search = "", string orderBy = WholeSalesReturnDispatchOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesReturnDispatchTransaction>(_configuraiton).GetObjectsAsync(new WholeSalesReturnDispatchTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code, search, orderBy, page, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransaction>>> GetWholeSalesReturnDispatchTransactionsByCurrentIdAsync(int id, string search = "", string orderBy = WholeSalesReturnDispatchOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesReturnDispatchTransaction>(_configuraiton).GetObjectsAsync(new WholeSalesReturnDispatchTransactionQuery(_configuraiton).GetTransactionByCurrentId(id,search,orderBy,page,pageSize));
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
