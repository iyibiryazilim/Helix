using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Domain.Models;
using Helix.ProductionService.Infrastructure.BaseRepository;
using Helix.ProductionService.Infrastructure.Helper;
using Helix.ProductionService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductionService.Infrastructure.Repository;

public class WorkOrderDataStore : BaseDataStore, IWorkOrderService
{
	ILogger<WorkOrderDataStore> _logger;
	public WorkOrderDataStore(IConfiguration configuration, ILogger<WorkOrderDataStore> logger) : base(configuration)
	{
		_logger = logger;
	}

	public async Task<DataResult<WorkOrder>> GetWorkOrderById(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<WorkOrder>(_configuraiton).GetObjectAsync(new WorkOrderQuery(_configuraiton).GetWorkOrderById(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}

	}

    public async Task<DataResult<IEnumerable<WorkOrder>>> GetWorkOrderByProductId(int id)
    {
        try
        {
            var result = await new SqlQueryHelper<WorkOrder>(_configuraiton).GetObjectsAsync(new WorkOrderQuery(_configuraiton).GetWorkOrderByProductId(id));
            _logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
            throw;
        }
    }

    public async Task<DataResult<IEnumerable<WorkOrder>>> GetWorkOrderByProductionOrderCode(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<WorkOrder>(_configuraiton).GetObjectsAsync(new WorkOrderQuery(_configuraiton).GetWorkOrderByProductionOrderCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}
		
	}

	public async Task<DataResult<IEnumerable<WorkOrder>>> GetWorkOrderByProductionOrderId(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<WorkOrder>(_configuraiton).GetObjectsAsync(new WorkOrderQuery(_configuraiton).GetWorkOrderByProductionOrderId(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}
		
	}

	public async Task<DataResult<IEnumerable<WorkOrder>>> GetWorkOrderByStatus(int[] status)
	{
		try
		{
			var result = await new SqlQueryHelper<WorkOrder>(_configuraiton).GetObjectsAsync(new WorkOrderQuery(_configuraiton).GetWorkOrderByStatus(status));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}

	}

	public async Task<DataResult<IEnumerable<WorkOrder>>> GetWorkOrderByWorkstationCode(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<WorkOrder>(_configuraiton).GetObjectsAsync(new WorkOrderQuery(_configuraiton).GetWorkOrderByWorkstationCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
			return result;
		} catch(Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}
		
	}

	public async Task<DataResult<IEnumerable<WorkOrder>>> GetWorkOrderByWorkstationId(int id)
	{
		
		try
		{
			var result = await new SqlQueryHelper<WorkOrder>(_configuraiton).GetObjectsAsync(new WorkOrderQuery(_configuraiton).GetWorkOrderByWorkstationId(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
			return result;
		}
		catch (Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}
	}

	public async Task<DataResult<IEnumerable<WorkOrder>>> GetWorkOrderList()
	{
		try
		{
			var result = await new SqlQueryHelper<WorkOrder>(_configuraiton).GetObjectsAsync(new WorkOrderQuery(_configuraiton).GetWorkOrderList());
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
