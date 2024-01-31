using Helix.LBSService.Tiger.Models;
using Helix.LBSService.Tiger.Models.BaseModel;
namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_WholeSalesDispatchTransactionService
	{
		public Task<DataResult<LG_WholeSalesDispatchTransaction>> Insert(LG_WholeSalesDispatchTransaction query);

	}
}
