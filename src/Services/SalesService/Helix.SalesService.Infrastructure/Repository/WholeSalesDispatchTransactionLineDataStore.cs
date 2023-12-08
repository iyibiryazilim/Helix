using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.BaseRepository;
using Helix.SalesService.Infrastructure.Helper;
using Helix.SalesService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.Tiger.DataAccess.DataStores;

public class WholeSalesDispatchTransactionLineDataStore : BaseDataStore,IWholeSalesDispatchTransactionLineService
{
	ILogger<WholeSalesDispatchTransactionLineDataStore> _logger;
	public WholeSalesDispatchTransactionLineDataStore(IConfiguration configuration,ILogger<WholeSalesDispatchTransactionLineDataStore> logger) : base(configuration)
	{
		_logger = logger;
	}

	public async Task<DataResult<WholeSalesDispatchTransactionLine>> GetWholeSalesDispatchTransactionLineByIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesDispatchTransactionLine>().GetObjectAsync(new WholeSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionById(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetWholeSalesDispatchTransactionLinesAsync()
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesDispatchTransactionLine>().GetObjectsAsync(new WholeSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionList());
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetWholeSalesDispatchTransactionLinesByCurrentCodeAsync(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesDispatchTransactionLine>().GetObjectsAsync(new WholeSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetWholeSalesDispatchTransactionLinesByCurrentIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesDispatchTransactionLine>().GetObjectsAsync(new WholeSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetWholeSalesDispatchTransactionLinesByFicheCodeAsync(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesDispatchTransactionLine>().GetObjectsAsync(new WholeSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetWholeSalesDispatchTransactionLinesByFicheIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesDispatchTransactionLine>().GetObjectsAsync(new WholeSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheId(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetWholeSalesDispatchTransactionLinesByProductCodeAsync(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesDispatchTransactionLine>().GetObjectsAsync(new WholeSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<WholeSalesDispatchTransactionLine>>> GetWholeSalesDispatchTransactionLinesByProductIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesDispatchTransactionLine>().GetObjectsAsync(new WholeSalesDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductId(id));
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
