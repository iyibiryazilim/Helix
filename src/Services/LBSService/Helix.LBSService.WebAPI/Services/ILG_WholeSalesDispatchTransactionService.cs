using Helix.LBSService.WebAPI.DTOs;
using Helix.LBSService.WebAPI.Models.BaseModel;
namespace Helix.LBSService.WebAPI.Services
{
	public interface ILG_WholeSalesDispatchTransactionService
	{
		public Task<DataResult<WholeSalesDispatchTransactionDto>> Insert(WholeSalesDispatchTransactionDto query);

	}
}
