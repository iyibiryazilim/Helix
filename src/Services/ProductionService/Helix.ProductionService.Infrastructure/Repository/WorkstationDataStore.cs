using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Domain.Models;
using Helix.ProductionService.Infrastructure.BaseRepository;
using Helix.ProductionService.Infrastructure.Helper;
using Helix.ProductionService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductionService.Infrastructure.Repository;

public class WorkstationDataStore : BaseDataStore, IWorkstationService
{
	ILogger<WorkstationDataStore> _logger;
	public WorkstationDataStore(IConfiguration configuration, ILogger<WorkstationDataStore> logger) : base(configuration)
	{
		_logger = logger;
	}

	public async Task<DataResult<Workstation>> GetWorkstationByCode(string code)
	{
		try
		{
			var result = await new SqlQueryHelper<Workstation>(_configuraiton).GetObjectAsync(new WorkstationQuery(_configuraiton).GetWorkstationByCode(code));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
			return result;
		} catch(Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}
		
	}

	public async Task<DataResult<Workstation>> GetWorkstationById(int id)
	{
		try
		{
			var result = await new SqlQueryHelper<Workstation>(_configuraiton).GetObjectAsync(new WorkstationQuery(_configuraiton).GetWorkstationById(id));
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
			return result;
		} catch(Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}
	}

	public async Task<DataResult<IEnumerable<Workstation>>> GetWorkstationList()
	{
		try
		{
			var result = await new SqlQueryHelper<Workstation>(_configuraiton).GetObjectsAsync(new WorkstationQuery(_configuraiton).GetWorkstationList());
			_logger.LogInformation(result.Message, DateTime.Now.ToLongTimeString());
			return result;
		} catch(Exception ex)
		{
			_logger.LogWarning(ex.Message, DateTime.Now.ToLongTimeString());
			throw;
		}
		
	}
}