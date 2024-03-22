using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;

namespace Helix.LBSService.WebAPI.Services
{
	public interface IWholeSalesReturnDispatchTransactionService
	{
		public Task<DataResult<WholeSalesReturnTransactionDto>> Insert(WholeSalesReturnTransactionDto dto);
	}
}