using Helix.LBSService.Tiger.Models;
using Helix.LBSService.Tiger.Models.BaseModel;
namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_RetailSalesDispatchTransactionService
	{
		public Task<DataResult<LG_RetailSalesDispatchTransaction>> Insert(LG_RetailSalesDispatchTransaction dto);

	}
}
