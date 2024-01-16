using Helix.SalesService.Application.Repository;
using Helix.SalesService.Domain.AggregateModels;
using Helix.SalesService.Domain.Models;
using Helix.SalesService.Infrastructure.BaseRepository;
using Helix.SalesService.Infrastructure.Helper;
using Helix.SalesService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.Tiger.DataAccess.DataStores;

public class SalesOrderDataStore : BaseDataStore, ISalesOrderService
{
	ILogger<SalesOrderDataStore> _logger;
	public SalesOrderDataStore(IConfiguration configuration,ILogger<SalesOrderDataStore> logger) : base(configuration)
	{
		_logger = logger;
	}

	public async Task<DataResult<SalesOrder>> GetSalesOrderByIdAsync(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrder>().GetObjectAsync(new SalesOrderQuery(_configuraiton).GetSalesOrderByIdQuery(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<SalesOrder>> GetSalesOrderByCode(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrder>().GetObjectAsync(new SalesOrderQuery(_configuraiton).GetSalesOrderByCodeQuery(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<SalesOrder>>> GetSalesOrdersAsync(string search = "", string orderBy = SalesOrdersOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrder>().GetObjectsAsync(new SalesOrderQuery(_configuraiton).GetSalesOrderQuery(search,orderBy,page,pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<SalesOrder>>> GetSalesOrdersByCurrentCodeAsync(string code, string search = "", string orderBy = SalesOrdersOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrder>().GetObjectsAsync(new SalesOrderQuery(_configuraiton).GetSalesOrderByCurrentCodeQuery(code, search, orderBy, page, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<SalesOrder>>> GetSalesOrdersByCurrentIdAsync(int id,string search= "", string orderBy = SalesOrdersOrderBy.DateDesc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrder>().GetObjectsAsync(new SalesOrderQuery(_configuraiton).GetSalesOrderByCurrentIdQuery(id, search, orderBy, page, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}
    public async Task<DataResult<IEnumerable<SalesOrder>>> GetSalesOrdersByCurrentIdAndWarehouseNumberAsync(int id,int number, string search = "", string orderBy = SalesOrdersOrderBy.DateDesc, int page = 0, int pageSize = 20)
    {
        try
        {
            var result = await new SqlQueryHelper<SalesOrder>().GetObjectsAsync(new SalesOrderQuery(_configuraiton).GetSalesOrderByCurrentIdAndWarehouseNumberQuery(id,number, search, orderBy, page, pageSize));
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
