using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Models.BaseModel;

namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_WholeSalesReturnDispatchTransactionService
	{
		public Task<DataResult<WholeSalesReturnTransactionDto>> Insert(WholeSalesReturnTransactionDto dto);

	}
}
