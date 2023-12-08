using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.BaseRepository;
using Helix.SalesService.Infrastructure.Helper;
using Helix.SalesService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.Tiger.DataAccess.DataStores;

public class SalesOrderLineDataStore : BaseDataStore, ISalesOrderLineService
{
	ILogger<SalesOrderLineDataStore> _logger;	
	public SalesOrderLineDataStore(IConfiguration configuration,ILogger<SalesOrderLineDataStore> logger) : base(configuration)
	{
		_logger = logger;
	}

	public async Task<DataResult<SalesOrderLine>> GetSalesOrderLineByCode(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrderLine>().GetObjectAsync(new SalesOrderLineQuery(_configuraiton).GetSalesOrderLineByCodeQuery(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<SalesOrderLine>> GetSalesOrderLineByIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrderLine>().GetObjectAsync(new SalesOrderLineQuery(_configuraiton).GetSalesOrderLineByIdQuery(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetSalesOrderLinesAsync()
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrderLine>().GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetSalesOrderLineQuery());
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetSalesOrdersByCurrentCodeAsync(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrderLine>().GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetSalesOrderLineByCurrentCodeQuery(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetSalesOrdersByCurrentIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrderLine>().GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetSalesOrderLineByCurrentIdQuery(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetSalesOrdersByProductCodeAsync(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrderLine>().GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetSalesOrderLineByProductCodeQuery(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetSalesOrdersByProductIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrderLine>().GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetSalesOrderLineByProductIdQuery(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrderLinesAsync()
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrderLine>().GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetWaitingSalesOrderLineQuery());
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrdersByCurrentCodeAsync(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrderLine>().GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetWaitingSalesOrderLineByCurrentCodeQuery(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrdersByCurrentIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrderLine>().GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetWaitingSalesOrderLineByCurrentIdQuery(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrdersByProductCodeAsync(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrderLine>().GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetWaitingSalesOrderLineByProductCodeQuery(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrdersByProductIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrderLine>().GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetWaitingSalesOrderLineByProductIdQuery(id));
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
