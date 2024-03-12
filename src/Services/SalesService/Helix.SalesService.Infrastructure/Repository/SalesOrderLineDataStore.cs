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
	public SalesOrderLineDataStore(IConfiguration configuration, ILogger<SalesOrderLineDataStore> logger) : base(configuration)
	{
		_logger = logger;
	}

	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetSalesOrderLineFicheByCodeAsync(string code, string search="", string orderBy = SalesOrderLineOrderBy.DueDateAsc, int page=0, int pageSize=20)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrderLine>(_configuraiton).GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetSalesOrderLineByFicheCodeQuery(code, search, orderBy, page, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}
	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrderLineFicheByCodeAsync(string code, string search = "", string orderBy = SalesOrderLineOrderBy.DueDateAsc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrderLine>(_configuraiton).GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetWaitingSalesOrderLineByFicheCodeQuery(code, search, orderBy, page, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetSalesOrderLineByFicheIdAsync(int id, string search = "", string orderBy = SalesOrderLineOrderBy.DueDateAsc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrderLine>(_configuraiton).GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetSalesOrderLineByFicheIdQuery(id, search, orderBy, page, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}
	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrderLineByFicheIdAsync(int id, string search = "", string orderBy = SalesOrderLineOrderBy.DueDateAsc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrderLine>(_configuraiton).GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetWaitingSalesOrderLineByFicheIdQuery(id, search, orderBy, page, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetSalesOrderLinesAsync(string search = "", string orderBy = SalesOrderLineOrderBy.DueDateAsc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrderLine>(_configuraiton).GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetSalesOrderLineQuery(search, orderBy, page, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetSalesOrdersByCurrentCodeAsync(string code, string search = "", string orderBy = SalesOrderLineOrderBy.DueDateAsc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrderLine>(_configuraiton).GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetSalesOrderLineByCurrentCodeQuery(code, search, orderBy, page, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetSalesOrdersByCurrentIdAsync(int id, string search = "", string orderBy = SalesOrderLineOrderBy.DueDateAsc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrderLine>(_configuraiton).GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetSalesOrderLineByCurrentIdQuery(id, search, orderBy, page, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetSalesOrdersByProductCodeAsync(string code, string search = "", string orderBy = SalesOrderLineOrderBy.DueDateAsc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrderLine>(_configuraiton).GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetSalesOrderLineByProductCodeQuery(code, search, orderBy, page, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetSalesOrdersByProductIdAsync(int id, string search = "", string orderBy = SalesOrderLineOrderBy.DueDateAsc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrderLine>(_configuraiton).GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetSalesOrderLineByProductIdQuery(id, search, orderBy, page, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrderLinesAsync(string search = "", string orderBy = SalesOrderLineOrderBy.DueDateAsc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrderLine>(_configuraiton).GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetWaitingSalesOrderLineQuery(search, orderBy, page, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrdersByCurrentCodeAsync(string code, string search = "", string orderBy = SalesOrderLineOrderBy.DueDateAsc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrderLine>(_configuraiton).GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetWaitingSalesOrderLineByCurrentCodeQuery(code, search, orderBy, page, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrdersByCurrentIdAsync(int id, string search = "", string orderBy = SalesOrderLineOrderBy.DueDateAsc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrderLine>(_configuraiton).GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetWaitingSalesOrderLineByCurrentIdQuery(id, search, orderBy, page, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAsync(int id, int warehouseNumber,string search = "", string orderBy = SalesOrderLineOrderBy.DueDateAsc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrderLine>(_configuraiton).GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetWaitingSalesOrderLineByCurrentIdAndWarehouseNumberQuery(id,warehouseNumber, search, orderBy, page, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

    public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrdersByCurrentIdAndWarehouseNumberAndShipInfoAsync(int id, int warehouseNumber,int shipInfoReferendeId, string search = "", string orderBy = SalesOrderLineOrderBy.DueDateAsc, int page = 0, int pageSize = 20)
    {
        try
        {
            var result = await new SqlQueryHelper<SalesOrderLine>(_configuraiton).GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetWaitingSalesOrderLineByCurrentIdAndWarehouseNumberAndShipInfoQuery(id, warehouseNumber,shipInfoReferendeId, search, orderBy, page, pageSize));
            _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

            throw;
        }
    }

    public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrdersByProductCodeAsync(string code, string search = "", string orderBy = SalesOrderLineOrderBy.DueDateAsc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrderLine>(_configuraiton).GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetWaitingSalesOrderLineByProductCodeQuery(code, search, orderBy, page, pageSize));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());

			throw;
		}
	}

	public async Task<DataResult<IEnumerable<SalesOrderLine>>> GetWaitingSalesOrdersByProductIdAsync(int id, string search = "", string orderBy = SalesOrderLineOrderBy.DueDateAsc, int page = 0, int pageSize = 20)
	{
		try
		{
			var result = await new SqlQueryHelper<SalesOrderLine>(_configuraiton).GetObjectsAsync(new SalesOrderLineQuery(_configuraiton).GetWaitingSalesOrderLineByProductIdQuery(id, search, orderBy, page, pageSize));
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
