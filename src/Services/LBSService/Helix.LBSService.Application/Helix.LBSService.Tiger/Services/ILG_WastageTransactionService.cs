using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.Models;

namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_WastageTransactionService
	{
		Task<DataResult<LG_WastageTransaction>> Insert(LG_WastageTransaction dto);

	}
}
