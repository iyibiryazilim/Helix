using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.Models;

namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_InCountingTransactionService
	{
		Task<DataResult<LG_InCountingTransaction>> Insert(LG_InCountingTransaction dto);

	}
}
