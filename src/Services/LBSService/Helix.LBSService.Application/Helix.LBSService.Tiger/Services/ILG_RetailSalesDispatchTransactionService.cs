using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.Models;

namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_RetailSalesDispatchTransactionService
	{
		public Task<DataResult<LG_RetailSalesDispatchTransaction>> Insert(LG_RetailSalesDispatchTransaction dto);

	}
}
