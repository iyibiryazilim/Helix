using Helix.LBSService.Base.Models;
using Helix.LBSService.Go.Models;

namespace Helix.LBSService.Go.Services
{
	public interface ILG_EINVOICEDET_Context
	{
		public Task<DataResult<LG_EINVOICEDET>> InsertAsync(LG_EINVOICEDET dto);

	}
}
