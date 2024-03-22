using Helix.LBSService.Base.Models;
using Helix.LBSService.Go.Models;

namespace Helix.LBSService.Go.Services
{
	public interface ILG_STLINE_Context
	{
		public Task<DataResult<LG_STLINE>> InsertAsync(LG_STLINE stline);
	}
}