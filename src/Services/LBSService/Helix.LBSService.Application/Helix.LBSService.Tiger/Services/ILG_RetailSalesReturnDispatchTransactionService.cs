using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Models.BaseModel;
namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_RetailSalesReturnDispatchTransactionService
	{
		public Task<DataResult<RetailSalesReturnDispatchTransactionDto>> Insert(RetailSalesReturnDispatchTransactionDto dto);

	}
}
