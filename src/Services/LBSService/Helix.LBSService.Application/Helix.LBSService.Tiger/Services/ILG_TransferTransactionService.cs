using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Models.BaseModel;
namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_TransferTransactionService
	{
		Task<DataResult<TransferTransactionDto>> Insert(TransferTransactionDto dto);
	}
}
