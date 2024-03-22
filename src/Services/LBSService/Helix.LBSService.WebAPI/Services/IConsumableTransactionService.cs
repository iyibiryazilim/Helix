using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;

namespace Helix.LBSService.WebAPI.Services
{
	public interface IConsumableTransactionService
	{
		public Task<DataResult<ConsumableTransactionDto>> Insert(ConsumableTransactionDto dto);
	}
}