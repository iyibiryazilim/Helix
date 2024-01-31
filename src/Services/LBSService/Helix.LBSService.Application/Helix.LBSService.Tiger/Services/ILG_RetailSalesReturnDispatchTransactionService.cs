using Helix.LBSService.Tiger.Models;
using Helix.LBSService.Tiger.Models.BaseModel;
namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_RetailSalesReturnDispatchTransactionService
	{
		public Task<DataResult<LG_RetailSalesReturnDispatchTransaction>> Insert(LG_RetailSalesReturnDispatchTransaction dto);

	}
}
