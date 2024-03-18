using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;

namespace Helix.LBSService.WebAPI.Services
{
	public interface IPurchaseDispatchTransactionService
	{
		public Task<DataResult<PurchaseDispatchTransactionDto>> Insert(PurchaseDispatchTransactionDto dto);

	}
}
