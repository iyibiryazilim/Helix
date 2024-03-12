using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.BaseRepository;
using Helix.SalesService.Infrastructure.Helper;
using Helix.SalesService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace Helix.Tiger.DataAccess.DataStores;

public class RetailSalesDispatchTransactionLineDataStore : BaseDataStore,IRetailSalesDispatchTransactionLineService
{
	private readonly ILogger<RetailSalesDispatchTransactionLineDataStore> _logger;
	public RetailSalesDispatchTransactionLineDataStore(IConfiguration configuration , ILogger<RetailSalesDispatchTransactionLineDataStore> logger) : base(configuration)
	{
		_logger = logger;
	}


	public async Task<DataResult<RetailSalesDispatchTransactionLine>> GetRetailSalesDispatchTransactionLineByIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<RetailSalesDispatchTransactionLine>(_configuraiton).GetObjectAsync(new RetailSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionById(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
			

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetRetailSalesDispatchTransactionLinesAsync(string search = "", string orderBy = RetailSalesDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<RetailSalesDispatchTransactionLine>(_configuraiton).GetObjectsAsync(new RetailSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionList(search, orderBy, page, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetRetailSalesDispatchTransactionLinesByCurrentCodeAsync(string code, string search = "", string orderBy = RetailSalesDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<RetailSalesDispatchTransactionLine>(_configuraiton).GetObjectsAsync(new RetailSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(code, search, orderBy, page, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetRetailSalesDispatchTransactionLinesByCurrentIdAsync(int id, string search = "", string orderBy = RetailSalesDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<RetailSalesDispatchTransactionLine>(_configuraiton).GetObjectsAsync(new RetailSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(id, search, orderBy, page, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetRetailSalesDispatchTransactionLinesByFicheCodeAsync(string code, string search = "", string orderBy = RetailSalesDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<RetailSalesDispatchTransactionLine>(_configuraiton).GetObjectsAsync(new RetailSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(code, search, orderBy, page, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetRetailSalesDispatchTransactionLinesByFicheIdAsync(int id, string search = "", string orderBy = RetailSalesDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<RetailSalesDispatchTransactionLine>(_configuraiton).GetObjectsAsync(new RetailSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheId(id, search, orderBy, page, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetRetailSalesDispatchTransactionLinesByProductCodeAsync(string code, string search = "", string orderBy = RetailSalesDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<RetailSalesDispatchTransactionLine>(_configuraiton).GetObjectsAsync(new RetailSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductCode(code, search, orderBy, page, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<RetailSalesDispatchTransactionLine>>> GetRetailSalesDispatchTransactionLinesByProductIdAsync(int id, string search = "", string orderBy = RetailSalesDispatchLineOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<RetailSalesDispatchTransactionLine>(_configuraiton).GetObjectsAsync(new RetailSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductId(id, search, orderBy, page, pageSize));
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
