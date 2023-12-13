using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Models.BaseModel;
namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_RetailSalesDispatchTransactionService
	{
		public Task<DataResult<RetailSalesDispatchTransactionDto>> Insert(RetailSalesDispatchTransactionDto dto);

	}
}
