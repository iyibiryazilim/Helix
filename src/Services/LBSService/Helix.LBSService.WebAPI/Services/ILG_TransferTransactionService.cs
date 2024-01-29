using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Models.BaseModel;
namespace Helix.LBSService.WebAPI.Services
{
	public interface ILG_TransferTransactionService
	{
		Task<DataResult<TransferTransactionDto>> Insert(TransferTransactionDto dto);
	}
}
