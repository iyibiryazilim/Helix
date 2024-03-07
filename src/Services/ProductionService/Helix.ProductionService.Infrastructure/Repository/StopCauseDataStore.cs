using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Domain.Models;
using Helix.ProductionService.Infrastructure.BaseRepository;
using Helix.ProductionService.Infrastructure.Helper;
using Helix.ProductionService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductionService.Infrastructure.Repository;

public class StopCauseDataStore : BaseDataStore, IStopCauseService
{
	ILogger<StopCauseDataStore> _logger;
	public StopCauseDataStore(IConfiguration configuration, ILogger<StopCauseDataStore> logger) : base(configuration)
	{
		_logger = logger;
	}

	public async Task<DataResult<IEnumerable<StopCause>>> GetStopCauseList()
	{
		try
		{
			var result = await new SqlQueryHelper<StopCause>(_configuraiton).GetObjectsAsync(new StopCauseQuery(_configuraiton).GetStopCauseList());
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
