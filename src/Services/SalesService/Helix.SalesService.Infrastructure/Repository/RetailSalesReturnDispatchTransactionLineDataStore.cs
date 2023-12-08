using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.BaseRepository;
using Helix.SalesService.Infrastructure.Helper;
using Helix.SalesService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.Tiger.DataAccess.DataStores;

public class RetailSalesReturnDispatchTransactionLineDataStore : BaseDataStore,IRetailSalesReturnDispatchTransactionLineService
{
	ILogger<RetailSalesReturnDispatchTransactionLineDataStore> _logger;
	public RetailSalesReturnDispatchTransactionLineDataStore(IConfiguration configuration,ILogger<RetailSalesReturnDispatchTransactionLineDataStore> logger) : base(configuration)
	{
		_logger = logger;
	}

	public async Task<DataResult<RetailSalesReturnDispatchTransactionLine>> GetRetailSalesReturnDispatchTransactionLineByIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<RetailSalesReturnDispatchTransactionLine>().GetObjectAsync(new RetailSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionById(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetRetailSalesReturnDispatchTransactionLinesAsync()
	{
		try
		{
			var result = await new SqlQueryHelper<RetailSalesReturnDispatchTransactionLine>().GetObjectsAsync(new RetailSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionList());
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetRetailSalesReturnDispatchTransactionLinesByCurrentCodeAsync(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<RetailSalesReturnDispatchTransactionLine>().GetObjectsAsync(new RetailSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetRetailSalesReturnDispatchTransactionLinesByCurrentIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<RetailSalesReturnDispatchTransactionLine>().GetObjectsAsync(new RetailSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetRetailSalesReturnDispatchTransactionLinesByFicheCodeAsync(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<RetailSalesReturnDispatchTransactionLine>().GetObjectsAsync(new RetailSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetRetailSalesReturnDispatchTransactionLinesByFicheIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<RetailSalesReturnDispatchTransactionLine>().GetObjectsAsync(new RetailSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheId(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetRetailSalesReturnDispatchTransactionLinesByProductCodeAsync(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<RetailSalesReturnDispatchTransactionLine>().GetObjectsAsync(new RetailSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<RetailSalesReturnDispatchTransactionLine>>> GetRetailSalesReturnDispatchTransactionLinesByProductIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<RetailSalesReturnDispatchTransactionLine>().GetObjectsAsync(new RetailSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductId(id));
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
