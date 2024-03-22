using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;

namespace Helix.LBSService.WebAPI.Services
{
	public interface IPurchaseReturnDispatchTransactionService
	{
		public Task<DataResult<PurchaseReturnDispatchTransactionDto>> Insert(PurchaseReturnDispatchTransactionDto dto);
	}
}