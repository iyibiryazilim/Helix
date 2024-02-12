using Helix.LBSService.Base.Models;
using Helix.LBSService.Go.Models;

namespace Helix.LBSService.Go.Services
{
	public interface ILG_STFICHE_Context
	{
		public Task<DataResult<LG_STFICHE>> InsertObject(LG_STFICHE item);
	}
}
