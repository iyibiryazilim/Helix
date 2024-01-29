using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Models.BaseModel;
namespace Helix.LBSService.WebAPI.Services
{
	public interface ILG_RetailSalesReturnDispatchTransactionService
	{
		public Task<DataResult<RetailSalesReturnDispatchTransactionDto>> Insert(RetailSalesReturnDispatchTransactionDto dto);

	}
}
