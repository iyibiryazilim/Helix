using Helix.LBSService.Tiger.DTOs;
using Helix.LBSService.Tiger.Models.BaseModel;
namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_InCountingTransactionService
	{
		Task<DataResult<InCountingTransactionDto>> Insert(InCountingTransactionDto dto);

	}
}
