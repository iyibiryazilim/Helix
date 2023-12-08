using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.BaseRepository;
using Helix.SalesService.Infrastructure.Helper;
using Helix.SalesService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.SalesService.Infrastructure.Repository;

public class RetailSalesDispatchTransactionDataStore : BaseDataStore, IRetailSalesDispatchTransactionService
{
	ILogger<RetailSalesDispatchTransactionDataStore> _logger;
    public RetailSalesDispatchTransactionDataStore(IConfiguration configuration,ILogger<RetailSalesDispatchTransactionDataStore> logger) : base(configuration)
    {
		_logger = logger;
    }

    public async Task<DataResult<RetailSalesDispatchTransaction>> GetRetailSalesDispatchTransactionByCode(string code)
    {
		try
		{
			var result = await new SqlQueryHelper<RetailSalesDispatchTransaction>().GetObjectAsync(new RetailSalesDispatchTransactionQuery(_configuraiton).GetTransactionByCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

    public async Task<DataResult<RetailSalesDispatchTransaction>> GetRetailSalesDispatchTransactionByIdAsync(int id)
    {
		try
		{
			var result = await new SqlQueryHelper<RetailSalesDispatchTransaction>().GetObjectAsync(new RetailSalesDispatchTransactionQuery(_configuraiton).GetTransactionById(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

    public async Task<DataResult<IEnumerable<RetailSalesDispatchTransaction>>> GetRetailSalesDispatchTransactionsAsync()
    {
		try
		{
			var result = await new SqlQueryHelper<RetailSalesDispatchTransaction>().GetObjectsAsync(new RetailSalesDispatchTransactionQuery(_configuraiton).GetTransactionList());
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

    public async Task<DataResult<IEnumerable<RetailSalesDispatchTransaction>>> GetRetailSalesDispatchTransactionsByCurrentCodeAsync(string code)
    {
		try
		{
			var result = await new SqlQueryHelper<RetailSalesDispatchTransaction>().GetObjectsAsync(new RetailSalesDispatchTransactionQuery(_configuraiton).GetTransactionByCurrentCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

    public async Task<DataResult<IEnumerable<RetailSalesDispatchTransaction>>> GetRetailSalesDispatchTransactionsByCurrentIdAsync(int id)
    {
		try
		{
			var result = await new SqlQueryHelper<RetailSalesDispatchTransaction>().GetObjectsAsync(new RetailSalesDispatchTransactionQuery(_configuraiton).GetTransactionByCurrentId(id));
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
