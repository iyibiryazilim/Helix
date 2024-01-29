using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Models.BaseModel;
namespace Helix.LBSService.WebAPI.Services
{
	public interface ILG_OutCountingTransactionService
	{
		Task<DataResult<OutCountingTransactionDto>> Insert(OutCountingTransactionDto dto);
	}
}
