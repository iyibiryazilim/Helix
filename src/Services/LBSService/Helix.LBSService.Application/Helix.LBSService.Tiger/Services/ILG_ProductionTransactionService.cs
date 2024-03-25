using Helix.LBSService.Base.Models;
using Helix.LBSService.Tiger.Models;

namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_ProductionTransactionService
	{
		Task<DataResult<LG_ProductionTransaction>> Insert(LG_ProductionTransaction dto);
	}
}