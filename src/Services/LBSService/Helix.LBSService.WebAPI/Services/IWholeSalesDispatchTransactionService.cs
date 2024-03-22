using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;

namespace Helix.LBSService.WebAPI.Services
{
	public interface IWholeSalesDispatchTransactionService
	{
		public Task<DataResult<WholeSalesDispatchTransactionDto>> Insert(WholeSalesDispatchTransactionDto dto);
	}
}