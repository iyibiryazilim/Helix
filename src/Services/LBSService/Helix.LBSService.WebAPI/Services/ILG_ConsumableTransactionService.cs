using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Models.BaseModel;
namespace Helix.LBSService.WebAPI.Services
{
	public interface ILG_ConsumableTransactionService
	{
		Task<DataResult<ConsumableTransactionDto>> Insert(ConsumableTransactionDto dto);

	}
}
