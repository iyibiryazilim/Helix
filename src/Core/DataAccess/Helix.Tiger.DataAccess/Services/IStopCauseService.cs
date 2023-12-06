using Helix.SharedEntity.BaseModels;
using Helix.SharedEntity.Models;

namespace Helix.Tiger.DataAccess.Services
{
	public interface IStopCauseService
	{
		public Task<DataResult<IEnumerable<StopCause>>> GetStopCauseList();

	}
}
