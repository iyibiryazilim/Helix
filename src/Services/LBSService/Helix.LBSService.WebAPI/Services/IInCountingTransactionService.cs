using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;

namespace Helix.LBSService.WebAPI.Services
{
	public interface IInCountingTransactionService
	{
		public Task<DataResult<InCountingTransactionDto>> Insert(InCountingTransactionDto dto);

	}
}
