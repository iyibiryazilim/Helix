using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services
{
	public interface IStopTransactionService
	{
		public Task<DataResult<IEnumerable<StopTransaction>>> GetStopTransactionList();
	}
}
