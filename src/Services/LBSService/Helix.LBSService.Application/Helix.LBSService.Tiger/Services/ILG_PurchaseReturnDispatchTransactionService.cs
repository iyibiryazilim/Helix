using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.Models;

namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_PurchaseReturnDispatchTransactionService
	{
		public Task<DataResult<LG_PurchaseReturnDispatchTransaction>> Insert(LG_PurchaseReturnDispatchTransaction dto);
	}
}