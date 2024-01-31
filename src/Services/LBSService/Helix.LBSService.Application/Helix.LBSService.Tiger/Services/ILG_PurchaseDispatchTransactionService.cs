using Helix.LBSService.Tiger.Models;
using Helix.LBSService.Tiger.Models.BaseModel;

namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_PurchaseDispatchTransactionService
	{
		public Task<DataResult<LG_PurchaseDispatchTransaction>> Insert(LG_PurchaseDispatchTransaction dto);
	}
}
