using Helix.Queries;
using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;
using Helix.Tiger.DataAccess.DataStores.Base;
using Helix.Tiger.DataAccess.Helper;
using Helix.Tiger.DataAccess.Services;
using Microsoft.Extensions.Configuration;

namespace Helix.Tiger.DataAccess.DataStores
{
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
}
