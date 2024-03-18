using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;

namespace Helix.LBSService.WebAPI.Services
{
	public interface IWastageTransactionService
	{
		public Task<DataResult<WastageTransactionDto>> Insert(WastageTransactionDto dto);

	}
}
