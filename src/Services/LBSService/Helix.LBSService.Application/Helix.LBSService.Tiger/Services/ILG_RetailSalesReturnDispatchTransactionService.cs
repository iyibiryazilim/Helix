using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.Models;


namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_RetailSalesReturnDispatchTransactionService
	{
		public Task<DataResult<LG_RetailSalesReturnDispatchTransaction>> Insert(LG_RetailSalesReturnDispatchTransaction dto);

	}
}
