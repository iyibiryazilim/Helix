using Helix.LBSService.Tiger.Models;
using Helix.LBSService.Tiger.Models.BaseModel;
namespace Helix.LBSService.Tiger.Services
{
	public interface ILG_WastageTransactionService
	{
		Task<DataResult<LG_WastageTransaction>> Insert(LG_WastageTransaction dto);

	}
}
