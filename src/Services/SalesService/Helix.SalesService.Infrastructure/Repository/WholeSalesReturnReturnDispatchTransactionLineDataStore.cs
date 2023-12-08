using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.BaseRepository;
using Helix.SalesService.Infrastructure.Helper;
using Helix.SalesService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.Tiger.DataAccess.DataStores;

public class WholeSalesReturnDispatchTransactionLineDataStore : BaseDataStore,IWholeSalesReturnDispatchTransactionLineService
{
	ILogger<WholeSalesReturnDispatchTransactionLineDataStore> _logger;
	public WholeSalesReturnDispatchTransactionLineDataStore(IConfiguration configuration,ILogger<WholeSalesReturnDispatchTransactionLineDataStore> logger) : base(configuration)
	{
		_logger = logger;
	}

	public async Task<DataResult<WholeSalesReturnDispatchTransactionLine>> GetWholeSalesReturnDispatchTransactionLineByIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesReturnDispatchTransactionLine>().GetObjectAsync(new WholeSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionById(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetWholeSalesReturnDispatchTransactionLinesAsync()
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesReturnDispatchTransactionLine>().GetObjectsAsync(new WholeSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionList());
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetWholeSalesReturnDispatchTransactionLinesByCurrentCodeAsync(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesReturnDispatchTransactionLine>().GetObjectsAsync(new WholeSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetWholeSalesReturnDispatchTransactionLinesByCurrentIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesReturnDispatchTransactionLine>().GetObjectsAsync(new WholeSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByCurrentId(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetWholeSalesReturnDispatchTransactionLinesByFicheCodeAsync(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesReturnDispatchTransactionLine>().GetObjectsAsync(new WholeSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetWholeSalesReturnDispatchTransactionLinesByFicheIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesReturnDispatchTransactionLine>().GetObjectsAsync(new WholeSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByFicheId(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetWholeSalesReturnDispatchTransactionLinesByProductCodeAsync(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesReturnDispatchTransactionLine>().GetObjectsAsync(new WholeSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<WholeSalesReturnDispatchTransactionLine>>> GetWholeSalesReturnDispatchTransactionLinesByProductIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<WholeSalesReturnDispatchTransactionLine>().GetObjectsAsync(new WholeSalesReturnDispatchTransactionLineQuery(_configuraiton).GetTransactionByProductId(id));
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
