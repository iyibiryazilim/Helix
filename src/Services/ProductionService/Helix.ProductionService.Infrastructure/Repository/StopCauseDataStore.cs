using Helix.ProductionService.Application.Services;
using Helix.ProductionService.Domain.Models;
using Helix.ProductionService.Infrastructure.BaseRepository;
using Helix.ProductionService.Infrastructure.Helper;
using Helix.ProductionService.Infrastructure.Helper.Queries;
using Microsoft.Extensions.Configuration;

namespace Helix.ProductionService.Infrastructure.Repository;

public class StopCauseDataStore : BaseDataStore, IStopCauseService
{
	public StopCauseDataStore(IConfiguration configuration) : base(configuration)
	{
	}

	public Task<DataResult<IEnumerable<StopCause>>> GetStopCauseList()
	{
		var result = new SqlQueryHelper<StopCause>().GetObjectsAsync(new StopCauseQuery(_configuraiton).GetStopCauseList());
		return result;
	}
}
