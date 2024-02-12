using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.Models;

namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_TransferTransactionService
	{
		Task<DataResult<LG_TransferTransaction>> Insert(LG_TransferTransaction dto);
	}
}
