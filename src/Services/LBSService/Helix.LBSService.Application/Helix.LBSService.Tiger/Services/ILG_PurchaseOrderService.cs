using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.Models;

namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_PurchaseOrderService
	{
		public Task<DataResult<LG_PurchaseOrder>> Insert(LG_PurchaseOrder dto);
	}
}