using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Domain.Models;
using Helix.ProductionService.Infrastructure.BaseRepository;
using Helix.ProductionService.Infrastructure.Helper;
using Helix.ProductionService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Helix.ProductionService.Infrastructure.Repository;

public class StopTransactionDataStore : BaseDataStore, IStopTransactionService
{
	ILogger<StopTransactionDataStore> _logger;
	public StopTransactionDataStore(IConfiguration configuration, ILogger<StopTransactionDataStore> logger) : base(configuration)
	{
		_logger = logger;
	}

	public async Task<DataResult<IEnumerable<StopTransaction>>> GetStopTransactionList()
	{
		try
		{
			var result = await new SqlQueryHelper<StopTransaction>().GetObjectsAsync(new StopTransactionQuery(_configuraiton).GetStopTransactionList());
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
