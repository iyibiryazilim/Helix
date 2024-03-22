using Helix.LBSService.Base.Models;
using Helix.LBSService.WebAPI.DTOs;

namespace Helix.LBSService.WebAPI.Services
{
	public interface IOutCountingTransactionService
	{
		public Task<DataResult<OutCountingTransactionDto>> Insert(OutCountingTransactionDto dto);
	}
}