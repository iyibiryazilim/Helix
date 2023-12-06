using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores
{
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
}
