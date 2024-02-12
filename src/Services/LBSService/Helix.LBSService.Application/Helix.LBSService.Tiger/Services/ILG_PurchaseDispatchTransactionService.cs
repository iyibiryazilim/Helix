using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.Models;

namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_PurchaseDispatchTransactionService
	{
		public Task<DataResult<LG_PurchaseDispatchTransaction>> Insert(LG_PurchaseDispatchTransaction dto);
	}
}
