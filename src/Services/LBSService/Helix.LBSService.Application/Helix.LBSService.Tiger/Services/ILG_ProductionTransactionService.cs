using Helix.LBSService.Tiger.Models;
using Helix.LBSService.Tiger.Models.BaseModel;
namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_ProductionTransactionService
	{
		Task<DataResult<LG_ProductionTransaction>> Insert(LG_ProductionTransaction dto);

	}
}
