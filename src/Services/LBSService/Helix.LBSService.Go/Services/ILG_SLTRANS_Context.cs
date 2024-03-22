using Helix.LBSService.Base.Models;
using Helix.LBSService.Go.Models;

namespace Helix.LBSService.Go.Services
{
	public interface ILG_SLTRANS_Context
	{
		public Task<DataResult<LG_SLTRANS>> InsertAsync(LG_SLTRANS dto);
	}
}