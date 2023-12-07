using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Domain.Models;
using Helix.ProductionService.Infrastructure.BaseRepository;
using Helix.ProductionService.Infrastructure.Helper;
using Helix.ProductionService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;

namespace Helix.ProductionService.Infrastructure.Repository;

public class StopTransactionDataStore : BaseDataStore, IStopTransactionService
{
	public StopTransactionDataStore(IConfiguration configuration) : base(configuration)
	{
	}

	public Task<DataResult<IEnumerable<StopTransaction>>> GetStopTransactionList()
	{
		var result = new SqlQueryHelper<StopTransaction>().GetObjectsAsync(new StopTransactionQuery(_configuraiton).GetStopTransactionList());
		return result;
	}
}
