using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Models.BaseModel;
namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_PurchaseReturnDispatchTransactionService
	{
		public Task<DataResult<PurchaseReturnDispatchTransactionDto>> Insert(PurchaseReturnDispatchTransactionDto dto);
	}
}
