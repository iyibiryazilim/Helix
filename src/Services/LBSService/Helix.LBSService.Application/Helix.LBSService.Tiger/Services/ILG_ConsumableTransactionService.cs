using Helix.LBSService.Tiger.Models;
using Helix.LBSService.Tiger.Models.BaseModel;
namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_ConsumableTransactionService
	{
		Task<DataResult<LG_ConsumableTransaction>> Insert(LG_ConsumableTransaction dto);

	}
}
