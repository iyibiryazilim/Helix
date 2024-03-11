using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.BaseRepository;
using Helix.SalesService.Infrastructure.Helper;
using Helix.SalesService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.Tiger.DataAccess.DataStores;

public class RetailSalesReturnDispatchTransactionDataStore : BaseDataStore,IRetailSalesReturnDispatchTransactionService
{
	ILogger<RetailSalesReturnDispatchTransactionDataStore> _logger;
	public RetailSalesReturnDispatchTransactionDataStore(IConfiguration configuration,ILogger<RetailSalesReturnDispatchTransactionDataStore> logger) : base(configuration)
	{
		_logger = logger;
	}

	public async Task<DataResult<RetailSalesReturnDispatchTransaction>> GetRetailSalesReturnDispatchTransactionByCode(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<RetailSalesReturnDispatchTransaction>(_configuraiton).GetObjectAsync(new RetailSalesReturnDispatchTransactionQuery(_configuraiton).GetTransactionByCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<RetailSalesReturnDispatchTransaction>> GetRetailSalesReturnDispatchTransactionByIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<RetailSalesReturnDispatchTransaction>(_configuraiton).GetObjectAsync(new RetailSalesReturnDispatchTransactionQuery(_configuraiton).GetTransactionById(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>> GetRetailSalesReturnDispatchTransactionsAsync(string search = "", string orderBy = RetailSalesReturnDispatchOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<RetailSalesReturnDispatchTransaction>(_configuraiton).GetObjectsAsync(new RetailSalesReturnDispatchTransactionQuery(_configuraiton).GetTransactionList(search, orderBy, page, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>> GetRetailSalesReturnDispatchTransactionsByCurrentCodeAsync(string code,string search = "", string orderBy = RetailSalesReturnDispatchOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<RetailSalesReturnDispatchTransaction>(_configuraiton).GetObjectsAsync(new RetailSalesReturnDispatchTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code, search, orderBy, page, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransaction>>> GetRetailSalesReturnDispatchTransactionsByCurrentIdAsync(int id, string search = "", string orderBy = RetailSalesReturnDispatchOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<RetailSalesReturnDispatchTransaction>(_configuraiton).GetObjectsAsync(new RetailSalesReturnDispatchTransactionQuery(_configuraiton).GetTransactionByCurrentId(id, search, orderBy, page, pageSize));
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
